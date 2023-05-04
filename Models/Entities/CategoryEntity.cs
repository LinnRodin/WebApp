using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class CategoryEntity
    {

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public ICollection<ProductEntity> Products { get; set; } = null!;
    }
}

