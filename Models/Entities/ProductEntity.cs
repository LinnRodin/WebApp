using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } = null!;

        [Column (TypeName = "money") ]
        public decimal? Price { get; set; } 
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; } 

       

    }
}
