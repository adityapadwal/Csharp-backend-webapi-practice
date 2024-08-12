// importing namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// current namespace
namespace ProductsCategoryApi.Models
{
    [Table("ProductTbl")]
    public class Product
    {
        public int Id { get; set; } // unique identifier for the product
        public string? Name { get; set; } // name of the product
        public decimal Price { get; set; } // price of the product
        public int CategoryId { get; set; } // foreign key that references category
        public Category? Category { get; set; } // navigation property to access corresponding category entity
    }
}
