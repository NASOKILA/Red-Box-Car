using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RedBoxCar.Web.Models
{
    [Table("Orders")]
    public class Orders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserId { get; set; }

        [Required(ErrorMessage ="Delivery Time is Required")]

        public int DeliveryTimeInMinutes { get; set; }

        [Required(ErrorMessage = "Total Price is Required")]
        public decimal TotalPrice { get; set; }

        public int ProductsCount { get; set; }
       
        [Required(ErrorMessage ="Creation Time is Required")]
        public  DateTime CreationTime { get; set; }

        public string PaymentMethod { get; set; }
    }
}
