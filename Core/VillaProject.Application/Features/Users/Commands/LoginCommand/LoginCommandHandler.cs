﻿using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Response<AuthResponse>>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Response<AuthResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(new AuthDto
            {
                Email = request.Email,
                Password = request.Password
            }, cancellationToken);

            return SuccessDataResponse<AuthResponse>.Success(result, 200);
        }
    }
}
