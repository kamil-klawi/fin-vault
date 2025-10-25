using IdentityService.Domain.Entities;
using IdentityService.Domain.Repositories;
using IdentityService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Contracts.Common;

namespace IdentityService.Infrastructure.Repositories
{
    public class UserRepository(UserDbContext userDbContext) : IUserRepository
    {
        public async Task<PagedResult<User>> GetUsersAsync(int pageNumber, int pageSize)
        {
            int totalCount = await userDbContext.Users.CountAsync();

            List<User> users = await userDbContext.Users
                .OrderBy(u => u.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<User>()
            {
                Items = users,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<User> GetUserAsync(Guid userId)
        {
            User? user = await userDbContext.Users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            User? user = await userDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            userDbContext.Users.Add(user);
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            userDbContext.Attach(user);
            userDbContext.Entry(user).State = EntityState.Modified;
            await userDbContext.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(Guid userId)
        {
            User? user = await userDbContext.Users.FindAsync(userId);
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            userDbContext.Users.Remove(user);
            await userDbContext.SaveChangesAsync();
        }

        public async Task DeleteUserByEmailAsync(string email)
        {
            User? user = await userDbContext.Users.FirstOrDefaultAsync(user => user.Email == email);
            if (user is null)
                throw new ArgumentNullException(nameof(user));

            userDbContext.Users.Remove(user);
            await userDbContext.SaveChangesAsync();
        }
    }
}
