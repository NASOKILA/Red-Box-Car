using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RedBoxCar.Web.Models
{
    [Table("Ingredients")]
    public class Ingredients
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Icon is Required")]
        public string Icon { get; set; }
    }
}
