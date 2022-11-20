using Service.DTO_s.Account;

namespace Service.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse> RegisterAsync(RegisterDTO model);
        Task<string?> LoginAsync(LoginDTO model);
        Task CreateRoleAsync(RoleDTO model);
    }
}
