using System.ComponentModel.DataAnnotations;

namespace Store_Manager.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}
