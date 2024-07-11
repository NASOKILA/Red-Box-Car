
namespace RedBoxCar.Web.Models.ViewModels
{
    public class PaymentMethodViewModel
    {
        public string PaymentSelected { get; set; }
        public int TotalItemsCount { get; set; }
        public int TotalPreparationtime { get; set; }
        public decimal TotalPrice { get; set; }
        public string CartItems { get; set; }
    }
}
