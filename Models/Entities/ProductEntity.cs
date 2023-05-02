using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace WebApp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        [Column (TypeName = "money") ]
        public decimal Price { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<string> Tags { get; set; } = new List<string>();


        //Tags = new List<string> { "featured", "new" }

        //public int CategoryId { get; set; }
        //public CategoryEntity Category { get; set; } = null!;
    }
}
