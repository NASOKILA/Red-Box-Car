using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace RedBoxCar.Web.Models
{
    [Table("Products")]
    public class Products
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Details is Required")]
        public string Details { get; set; }
        
        [Required(ErrorMessage = "Image is Required")]
        public string Image { get; set; }
        public string Type { get; set; }

        public int Rating { get; set; }
        
        [Required(ErrorMessage ="Preparatoin Time is Required")]
        public int PreparationTimeInMinutes { get; set; }
        
        public int IngredientsListId { get; set; }
        
        public List <Ingredients> IngredientsList { get; set; }
        public decimal Price { get; internal set; }
    }
}
