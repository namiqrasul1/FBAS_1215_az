using System.ComponentModel.DataAnnotations;

namespace Lesson8ViewModelsAndDTO.Models.ViewModels
{
    public class UserLoginViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

        //public static implicit operator User(UserLoginViewModel model)
        //{
        //    return new User() { Password = model.Password, Username = model.UserName};
        //}

        //public static implicit operator UserLoginViewModel(User model)
        //{
        //    return new UserLoginViewModel() { Password = model.Password, UserName = model.Username };
        //}

        public static explicit operator User(UserLoginViewModel model)
        {
            return new User() { Password = model.Password, UserName = model.UserName };
        }

        public static explicit operator UserLoginViewModel(User model)
        {
            return new UserLoginViewModel() { Password = model.Password, UserName = model.UserName };
        }
    }
}
