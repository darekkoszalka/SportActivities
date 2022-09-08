using System;
using AccountManager.Domain.Entities;

namespace AccountManager.Domain.IRepositories;

public interface IUserRepository
{
    Task<IList<User>> GetAll();
    Task<Guid> Register(User user);
    Task Update(User user);
    Task Delete(User user);
    Task<bool> UserExists(string userEmail);
    Task<User> GetUserById(Guid userId);
}

