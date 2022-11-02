using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.Commands.AddUserRoleCommand
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommandRequest, Result>
    {
        private readonly IUserService _userService;

        public AddUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(AddUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.AddUserRoleAsync(request.UserId, request.RoleName, cancellationToken);
            return SuccessResult.Success(200);
        }
    }
}
