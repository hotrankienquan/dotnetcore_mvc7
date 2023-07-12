using dotnet_mvc.Models.Domain;
using dotnet_mvc.Repositories.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mvc.Controllers
{
    public class GenreController : Controller
    {

        private readonly IGenreService _service;
        public GenreController(IGenreService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Genre model) { 
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Add(model);
            if(result)
            {
                TempData["message"] = "success";
                return RedirectToAction(nameof(Add));

            }
            TempData["message"] = "failed";
            return View(model);
        }
        public IActionResult GetAll()
        {
            var data = _service.FindAll();
            if(data != null)
            {
                return View(data);
            }
            return View();

        }
        public IActionResult Update(int id)
        {
            var data = _service.FindById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Genre model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = _service.Update(model);
            if (result)
            {
                TempData["message"] = "success";
                return RedirectToAction("GetAll");

            }
            TempData["message"] = "failed";
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var data = _service.Delete(id);
            if(data)
            {
                return RedirectToAction("GetAll");

            }
            return View();
        }
    }
}
