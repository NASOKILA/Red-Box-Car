using Microsoft.AspNetCore.Mvc;

namespace RedBoxCar.Web.Controllers
{
    public class OrdersStatusController : Controller
    {
        private readonly ILogger<OrdersStatusController> _logger;

        public OrdersStatusController(ILogger<OrdersStatusController> logger)
        {
            _logger = logger;
        }

        public IActionResult OrderStatus()
        {
            return View();
        }
    }
}
