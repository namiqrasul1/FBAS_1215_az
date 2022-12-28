using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> users = new();

    public void AddUser(User user)
    {
        users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return users.Find(u => u.Email == email);
    }
}
