using System.ComponentModel.DataAnnotations;

namespace RedBoxCar.Web.Models.ViewModels
{
    public class CheckoutViewModel
    {

        [Required]
        [Display(Name = "StreetAddress")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "TownCity")]
        public string TownCity { get; set; }


        [Required]
        [Display(Name = "ZipCode")]
        public string ZipCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public int TotalItemsCount { get; set; }
        public int TotalPreparationtime { get; set; }
        public decimal TotalPrice { get; set; }
        public string CartItems { get; set;}
    }
}
