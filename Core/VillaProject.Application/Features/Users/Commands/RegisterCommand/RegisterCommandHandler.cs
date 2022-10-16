﻿using MediatR;
using VillaProject.Application.Dtos.Identities;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.RegisterCommand
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest,Response>
    {
        private readonly IUserService _userService;

        public RegisterCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Response> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            if (!request.Password.Equals(request.PasswordConfirm))
                return ErrorResponse.Fail("Password and password confirm are not same!", 400);

            var userId = await _userService.RegisterAsync(
                new RegistrationDto
                {
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Password = request.Password,
                    UserName = request.UserName
                }, cancellationToken);

            return SuccessDataResponse.Success(userId, 200);
        }
    }
}
