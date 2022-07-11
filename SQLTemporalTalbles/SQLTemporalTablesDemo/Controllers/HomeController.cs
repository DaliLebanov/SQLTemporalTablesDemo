using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLTemporalTablesDemo.Data.DataModels;
using SQLTemporalTablesDemo.Managers;
using SQLTemporalTablesDemo.Models;
using System.Diagnostics;

namespace SQLTemporalTablesDemo.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPersonManager _personManager;

        public HomeController(IPersonManager personManager)
        {
            _personManager = personManager;
        }

        public IActionResult Index()
        {
            var persons = _personManager.GetAllPersons();

            return View(persons);
        }

        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person model)
        {
            _personManager.Insert(model);
            return RedirectToAction("Index");
        }

       
        public IActionResult EditPerson(int id)
        {
            var person = _personManager.GetById(id);
            return View(person);
        }
        [HttpPost]
        public IActionResult UpdatePerson(Person model)
        {
            _personManager.Update(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeletePerson(int id)
        {
            _personManager.Delete(id);
            return RedirectToAction("Index");
        }
    }
}