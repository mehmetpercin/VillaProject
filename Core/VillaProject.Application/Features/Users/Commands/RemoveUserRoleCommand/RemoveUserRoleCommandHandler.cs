using MediatR;
using VillaProject.Application.Dtos.Responses;
using VillaProject.Application.Services;

namespace VillaProject.Application.Features.Users.Commands.RemoveUserRoleCommand
{
    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommandRequest, Result>
    {
        private readonly IUserService _userService;

        public RemoveUserRoleCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(RemoveUserRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await _userService.RemoveUserRoleAsync(request.UserId, request.RoleName, cancellationToken);
            return SuccessResult.Success(200);
        }
    }
}
