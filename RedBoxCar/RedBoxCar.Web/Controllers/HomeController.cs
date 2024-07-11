using Microsoft.AspNetCore.Mvc;
using RedBoxCar.Web.Data;
using RedBoxCar.Web.Models;
using RedBoxCar.Web.Models.ViewModels;
using System.Diagnostics;

namespace RedBoxCar.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }


        public IActionResult Index(int pageNumber = 1, string searchString = null)
        {
            if (searchString != null)
            {
                return RenderViewWhenSearchStringIsProvided(out pageNumber, searchString);
            }
            else
            {
                return RenderViewWhenNoSearchStringIsProvided(pageNumber, searchString);
            }
        }

        private IActionResult RenderViewWhenSearchStringIsProvided(out int pageNumber, string searchString)
        {
            var query = _db.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            List<Products> allProducts = query.ToList();

            if (allProducts[0].Type == "Meal")
            {
                pageNumber = 1;
            }
            else
            {
                pageNumber = 2;
            }

            ViewData["PageNumber"] = pageNumber;
            ViewData["CurrentSearchString"] = searchString;

            return View(allProducts);
        }

        private IActionResult RenderViewWhenNoSearchStringIsProvided(int pageNumber, string searchString)
        {
            var query = _db.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            List<Products> allProducts = pageNumber == 1
                ? query.Where(p => p.Type == "Meal").ToList()
                : query.Where(p => p.Type == "Dessert").ToList();

            ViewData["PageNumber"] = pageNumber;
            ViewData["CurrentSearchString"] = searchString;

            return View(allProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}