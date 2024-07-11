using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedBoxCar.Web.Data;

namespace RedBoxCar.Web.Controllers
{
    public class ProductDetailsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public ProductDetailsController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult ProductDetails(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);

            _logger.LogInformation($"Product Details fetched - {JsonConvert.SerializeObject(product)}");

            if (product == null) {
                return NotFound();
            }

            return View(product);
        }
    }
}
