using RedBoxCar.Web.Models;

namespace RedBoxCar.Web.Views.CheckOut
{
    public class CartProductModel
    {
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
