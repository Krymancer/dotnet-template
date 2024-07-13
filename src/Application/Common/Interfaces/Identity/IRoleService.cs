using Application.Features.Roles.Requests.Commands;

namespace Application.Common.Interfaces.Identity;

public interface IRoleService
{
    Task<BaseResponse<string>> CreateRole(CreateRoleCommand request);
    Task<BaseResponse<string>> EditRole(EditRoleCommand request);
    Task<BaseResponse<string>> DeleteRole(DeleteRoleCommand request);
    Task<BaseResponse<string>> AddClaimToRole(AddClaimToRoleCommand request);
    Task<BaseResponse<string>> AddRoleToUser(AssignRoleToUserCommand request);
    Task<BaseResponse<string>> AddClaimToUser(AssignClaimToUserCommand request);
    Task<BaseResponse<IEnumerable<string>>> GetUserRoles(string userId);
    Task<BaseResponse<IEnumerable<string>>> GetUserClaims(string userId);
    Task<BaseResponse<IEnumerable<string>>> GetRoleClaims(string roleName);
    Task<BaseResponse<IEnumerable<string>>> GetAllRoles();
    Task<BaseResponse<IEnumerable<string>>> GetAllClaims();
}