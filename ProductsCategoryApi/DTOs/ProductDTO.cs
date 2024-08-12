// current namespace
namespace ProductsCategoryApi.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; } // unique identifier for the product
        public string? Name { get; set; } // name of the product
        public decimal Price { get; set; } // price of the product
        public int CategoryId { get; set; } // categoryId of the product
    }
}
