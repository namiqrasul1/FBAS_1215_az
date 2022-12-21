using JWTLoginRegister.Dtos;
using JWTLoginRegister.Models;

namespace JWTLoginRegister.Repos
{
    public static class UserRepository
    {
        public static List<User> users = new()
        {
            new(){UserName = "murad", Password="Muradyek", Role="User"},
            new(){UserName = "hassan", Password="oxumursanHassan", Role="Admin"},
        };

        public static void AddUser(User user) { users.Add(user); }
        
        public static User GetUser(UserDto user) {  return users.FirstOrDefault(x => x.UserName.ToLower() == user.UserName.ToLower() && x.Password == user.Password); }
    }
}
