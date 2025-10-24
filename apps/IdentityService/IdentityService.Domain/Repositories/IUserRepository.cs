using IdentityService.Domain.Entities;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<PagedResult<User>> GetUsersAsync(int pageNumber, int pageSize);
        Task<User> GetUserAsync(Guid userId);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> CreateUserAsync(User user);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid userId);
        Task DeleteUserByEmailAsync(string email);
    }
}
