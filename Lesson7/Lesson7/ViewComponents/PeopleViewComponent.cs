using Lesson7.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson7.ViewComponents
{
    public class PeopleViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            List<Person> persons = new()
            {
                new() { Name ="Zaur", Surname="Aliyev"},
                new() { Name ="Murad", Surname="Musayev"},
                new() { Name ="Turan", Surname="Bedelsoy"},
                new() { Name ="Hassan", Surname="Rzayev"},
            };

            return View(persons);
        }
    }
}
