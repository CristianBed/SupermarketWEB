using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMarketWEB.Models
{
    public class Product
    {
        // [kEY] --> ANOTACION SI LA PROPIEEDA NO SE LLAMA ID , EJEMPLO ProductuID

        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(6,2)")]

        public decimal Price { get; set; }
        public int Stock { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}

