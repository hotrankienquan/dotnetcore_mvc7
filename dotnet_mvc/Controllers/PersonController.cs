using dotnet_mvc.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using System;

namespace dotnet_mvc.Controllers
{
    public class PersonController : Controller
    {
        private readonly DatabaseContext _ctx;
        public PersonController(DatabaseContext ctx) { 
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            // viewbag and viewdata canpass data to view 
            ViewBag.greeting = "hello with view bag";
            ViewData["greeting2"] = "hello with view data";
            // tempdata can pass data from method controller to method controller
            TempData["greeting3"] = "Hello with temp data,";
            return View();
        }
        public IActionResult AddPerson()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person person) {
            Console.WriteLine(person.Name);
            if(!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Add(person);
                _ctx.SaveChanges();
                TempData["message"] = "added successfully";
                return RedirectToAction("AddPerson");
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["message"] = "add failed";
                return View();
            }
        }

        public IActionResult DisplayPersons()
        {
            var persons = _ctx.Person.ToList();
            Console.WriteLine(persons + "this is from log display persons");
            return View(persons);
        }

        // edit has 1 method to get person info and 1 method to update new info 

        public IActionResult EditPerson(int id) {
            var person = _ctx.Person.Find(id);
            return View(person);

        }
        [HttpPost]
        public IActionResult EditPerson(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _ctx.Update(person);
                _ctx.SaveChanges();
                TempData["message"] = "update successfully";
                return RedirectToAction("DisplayPersons");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                TempData["message"] = "updated failed";
                return View();
            }
        }
        public IActionResult DeletePerson(int id)
        {
            try
            {
                var person = _ctx.Person.Find(id);
                if(person != null)
                {
                    _ctx.Person.Remove(person);
                    _ctx.SaveChanges();
                }
                return RedirectToAction("DisplayPersons");
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
    }
}
