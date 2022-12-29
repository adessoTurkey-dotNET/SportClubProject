using Microsoft.AspNetCore.Mvc;
using VolleyballClubProject.Core.Entities;
using VolleyballClubProject.Core.Interfaces;

namespace VolleyballClubProject.Client.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public void AddPerson(Person person)
        {
            _personService.AddPerson(person);
        }
        [HttpGet]
        public Person GetPerson(int id)
        {
            return null;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
