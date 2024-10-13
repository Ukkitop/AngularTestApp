using AngularTestApp.Database.Context;
using AngularTestApp.Database.Entities;
using AngularTestApp.Database.Interfaces;

namespace AngularTestApp.Database.Repository;

public class UserRepository(AngularTestAppDbContext context) : IUserRepository
{
    public async Task SaveUser(UserEntity user)
    {
        var result = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
    }
}