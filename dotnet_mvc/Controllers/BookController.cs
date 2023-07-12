using dotnet_mvc.Models.Domain;
using dotnet_mvc.Repositories.Abstract;
using dotnet_mvc.Repositories.Implementation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dotnet_mvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IGenreService genreService;
        private readonly IBookService bookService;

        public BookController(IGenreService genreService, IBookService bookService)
        {
            this.genreService = genreService;
            this.bookService = bookService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            var model = new Book();
            model.GenreList = genreService.FindAll().Select(
                a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }
            ).ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Book model)
        {
            model.GenreList = genreService.FindAll().Select(
                a => new SelectListItem { Text = a.Name, Value = a.Id.ToString() }
            ).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Add(model);
            Console.Write(result);
            if (result)
            {
                TempData["message"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }

        public IActionResult GetAll()
        {
            var data = bookService.FindAll();

            return View(data);
        }

        public IActionResult Delete(int id)
        {

            var result = bookService.Delete(id);
            return RedirectToAction("GetAll");
        }
        public IActionResult Update(int id)
        {
            var model = bookService.FindById(id);
            model.GenreList = genreService.FindAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(Book model)
        {
            model.GenreList = genreService.FindAll().Select(a => new SelectListItem { Text = a.Name, Value = a.Id.ToString(), Selected = a.Id == model.GenreId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = bookService.Update(model);
            if (result)
            {
                return RedirectToAction("GetAll");
            }
            TempData["message"] = "Error has occured on server side";
            return View(model);
        }

    }
}
