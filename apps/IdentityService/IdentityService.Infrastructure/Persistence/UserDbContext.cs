using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Persistence
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(builder =>
            {
                builder.OwnsOne(user => user.Email);
                builder.OwnsOne(user => user.PasswordHash);
                builder.OwnsOne(user => user.PersonalData, options =>
                {
                    options.OwnsOne(personalData => personalData.Pesel);
                    options.OwnsOne(personalData => personalData.Address);
                    options.OwnsOne(personalData => personalData.PhoneNumber);
                });
            });
        }
    }
}
