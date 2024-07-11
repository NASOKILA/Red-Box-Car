using Microsoft.AspNetCore.Mvc;
using RedBoxCar.Web.Models.ViewModels;

namespace RedBoxCar.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ILogger<CheckoutController> _logger;

        public CheckoutController(ILogger<CheckoutController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> CheckOut(CheckoutViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TotalItemsCount"] = model.TotalItemsCount;
                ViewData["TotalPreparationTime"] = model.TotalPreparationtime;
                ViewData["TotalPrice"] = model.TotalPrice;
                ViewData["CartItems"] = model.CartItems;

                return View(model);
            }

           _logger.LogInformation($"Checkout with: {model.Phone}, {model.ZipCode}, {model.StreetAddress}, {model.TownCity}.");

            return RedirectToAction("Payment", "Payment", 
                new { totalItemsCount = model.TotalItemsCount, totalPreparationtime = model.TotalPreparationtime, totalPrice = model.TotalPrice, cartItems= model.CartItems });
        }


        public IActionResult CheckOut(int itemsCount, int totalPreparationtime, decimal totalPrice, string cartItems)
        {
            ViewData["TotalItemsCount"] = itemsCount;
            ViewData["TotalPreparationTime"] = totalPreparationtime;
            ViewData["TotalPrice"] = totalPrice;
            ViewData["CartItems"] = cartItems;

            return View();
        }
    }
}