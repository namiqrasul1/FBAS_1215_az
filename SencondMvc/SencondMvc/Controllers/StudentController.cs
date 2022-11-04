using Microsoft.AspNetCore.Mvc;
using SencondMvc.Models;

namespace SencondMvc.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet] // default
        public IActionResult CreateStudent()
        {
            var student = new Student() { Age= 42, Name="Hakuna", Surname="Matata"};
            return View(student);
        }

        //[HttpPost]
        //public IActionResult CreateStudent(IFormCollection keyValuePairs)
        //{
        //    var name = keyValuePairs["txtName"].ToString();
        //    var surname = keyValuePairs["txtSurname"].ToString();
        //    var age = keyValuePairs["txtAge"].ToString();

        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateStudent(string txtName, string txtSurname, int age)
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {

            return View();
        }

    }
}
