using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Services;
using VillaProject.Domain.Exceptions;
using VillaProject.Identity.Entities;
using VillaProject.Identity.Models;

namespace VillaProject.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly IdentityAppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenOption _tokenOption;

        public AuthService(IdentityAppDbContext dbContext,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IOptions<TokenOption> options)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenOption = options.Value;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new IdentityException("Email or Password is wrong!");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                throw new IdentityException("Email or Password is wrong!");
            }

            var token = await GenerateAccessTokenAsync(user);
            var refreshToken = GenerateRefreshToken();

            var userRefreshToken = await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(x => x.UserId == user.Id, cancellationToken);
            if (userRefreshToken is not null)
            {
                userRefreshToken.RefreshToken = refreshToken;
                userRefreshToken.Expiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
            }
            else
            {
                var newUserRefreshToken = new UserRefreshToken
                {
                    Expiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration),
                    RefreshToken = refreshToken,
                    UserId = user.Id
                };

                await _dbContext.UserRefreshTokens.AddAsync(newUserRefreshToken, cancellationToken);
            }

            await _dbContext.SaveChangesAsync(cancellationToken);

            var response = new AuthResponse
            {
                Id = user.Id,
                AccessToken = token,
                Email = user.Email,
                UserName = user.UserName,
                RefreshToken = refreshToken
            };

            return response;
        }

        public async Task<AuthResponse> LoginWithRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
        {
            var userRefreshToken = await _dbContext.UserRefreshTokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken, cancellationToken);
            if (userRefreshToken is null)
                throw new IdentityException("Token not found!");

            if (userRefreshToken.Expiration < DateTime.Now)
                throw new IdentityException("Token has expired!");

            var user = await _userManager.FindByIdAsync(userRefreshToken.UserId);
            var token = await GenerateAccessTokenAsync(user);
            var newRefreshToken = GenerateRefreshToken();
            userRefreshToken.RefreshToken = newRefreshToken;

            var response = new AuthResponse
            {
                Id = user.Id,
                AccessToken = token,
                Email = user.Email,
                UserName = user.UserName,
                RefreshToken = newRefreshToken
            };
            return response;
        }

        private async Task<string> GenerateAccessTokenAsync(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();
            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOption.SecurityKey));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                audience: _tokenOption.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration),
                signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(jwtSecurityToken);
            return token;
        }

        private string GenerateRefreshToken()
        {
            var numberByte = new byte[32];
            using var rnd = RandomNumberGenerator.Create();
            rnd.GetBytes(numberByte);
            return Convert.ToBase64String(numberByte);
        }
    }
}
