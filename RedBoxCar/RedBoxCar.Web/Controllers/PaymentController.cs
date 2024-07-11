using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedBoxCar.Web.Data;
using RedBoxCar.Web.Models;
using RedBoxCar.Web.Models.ViewModels;

namespace RedBoxCar.Web.Controllers
{
    public class PaymentController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(UserManager<IdentityUser> userManager, ILogger<PaymentController> logger, ApplicationDbContext db)
        {
            _userManager = userManager;
            _logger = logger;
            _db = db;
        }

        public IActionResult Payment(int totalItemsCount, int totalPreparationtime, decimal totalPrice, string cartItems)
        {
            ViewData["TotalItemsCount"] = totalItemsCount;
            ViewData["TotalPreparationTime"] = totalPreparationtime;
            ViewData["TotalPrice"] = totalPrice;
            ViewData["CartItems"] = cartItems;


            var paymentMethodViewModel = new PaymentMethodViewModel();
            
            return View(paymentMethodViewModel);
        }

        [HttpPost]
        public IActionResult Payment(PaymentMethodViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TotalItemsCount"] = model.TotalItemsCount;
                ViewData["TotalPreparationTime"] = model.TotalPreparationtime;
                ViewData["TotalPrice"] = model.TotalPrice;
                ViewData["CartItems"] = model.CartItems;
                ViewData["PaymentSelected"] = model.PaymentSelected;

                return View(model);
            }

            // Get ProductIds in a list
            var producutsIdsList = JsonConvert.DeserializeObject<List<string>>(model.CartItems);

            var currentgUser = _userManager.GetUserAsync(User).Result;

            // Build the order object
            var newOrder = new Orders()
            {
                CreationTime = DateTime.Now,
                DeliveryTimeInMinutes = model.TotalPreparationtime,
                ProductsCount = producutsIdsList.Count,
                TotalPrice = model.TotalPrice,
                UserId = currentgUser.Id,
                PaymentMethod = model.PaymentSelected,
            };
            // Save order in the database.

            _db.Orders.Add(newOrder);

            _db.SaveChanges();

            _logger.LogInformation("Saving new order into the database - " + JsonConvert.SerializeObject(model));

            return RedirectToAction("Index", "Home");
        }
    }
}