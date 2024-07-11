using Microsoft.AspNetCore.Mvc;
using RedBoxCar.Web.Data;
using RedBoxCar.Web.Views.CheckOut;
using System.Text.Json;

namespace RedBoxCar.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        private readonly ILogger<HomeController> _logger;

        public OrdersController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Cart(string cartItemIds)
        {
            if (string.IsNullOrEmpty(cartItemIds))
            {
                return View(new List<CartProductModel>());
            }

            var itemIds = JsonSerializer.Deserialize<List<string>>(cartItemIds);
            var cartProductModelList = new List<CartProductModel>();

            foreach (var itemId in itemIds)
            {
                if (!int.TryParse(itemId, out int parsedItemId))
                    continue;

                var existingCartProduct = cartProductModelList.FirstOrDefault(c => c.Product.Id == parsedItemId);
                if (existingCartProduct != null)
                {
                    existingCartProduct.Quantity++;
                    existingCartProduct.Total += existingCartProduct.Product.Price;
                }
                else
                {
                    var product = _db.Products.FirstOrDefault(p => p.Id == parsedItemId);
                    if (product != null)
                    {
                        cartProductModelList.Add(new CartProductModel() { Product = product, Quantity = 1, Total = product.Price });
                    }
                }
            }

            return View(cartProductModelList);
        }
    }
}


public class CartViewModel
{
    public string OrderDetails { get; set; }
    public decimal TotalPrice { get; set; }
}
