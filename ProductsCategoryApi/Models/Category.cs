// importing namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// current namepsace
namespace ProductsCategoryApi.Models
{
    [Table("CategoryTbl")]
    public class Category
    {
        [Key]
        public int Id { get; set; } // unique identifier for the category

        public string? Name { get; set; } // name of the category

        public ICollection<Product>? Products { get; set; } // collection of products (used for navigation)
    }
}
