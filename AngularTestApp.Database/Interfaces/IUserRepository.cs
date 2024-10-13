using AngularTestApp.Database.Entities;

namespace AngularTestApp.Database.Interfaces;

public interface IUserRepository
{
    Task SaveUser(UserEntity user);
}