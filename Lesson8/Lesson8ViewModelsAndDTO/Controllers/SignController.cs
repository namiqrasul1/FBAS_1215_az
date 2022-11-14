using Lesson8ViewModelsAndDTO.Models;
using Lesson8ViewModelsAndDTO.Models.ViewModels;
using Lesson8ViewModelsAndDTO.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lesson8ViewModelsAndDTO.Controllers
{
    public class SignController : Controller
    {

        public IActionResult In()
        {
            return View();
        }

        public IActionResult Up()
        {
            var user = new User();
            var obj = (user.UserName, user.Password);

            return View(obj);
        }

        [HttpPost]
        public IActionResult Up(User user)
        {
            return View(user);
        }

        [HttpPost]
        public IActionResult In(UserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                #region Manual
                //User user = new() { Surname = model.UserName, Password = model.Password };
                #endregion

                #region ImplicitOperatorOverload
                //User user = model;
                //UserLoginViewModel loginViewModel = user;


                #endregion

                #region ExplicitOperatorOverload

                //User user = (User)model;
                //UserLoginViewModel loginViewModel = (UserLoginViewModel)user;

                #endregion

                #region Reflection
                User user = TypeConversion.Convert<User, UserLoginViewModel>(model);
                UserLoginViewModel loginViewModel = TypeConversion.Convert<UserLoginViewModel, User>(user);


                #endregion

                return View();
            }
            return View("Error.cshtml");
        }

    }
}
