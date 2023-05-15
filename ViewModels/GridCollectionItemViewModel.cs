using WebApp.Models.Entities;

namespace WebApp.ViewModels
{
    public class GridCollectionItemViewModel
    {
        public string Id { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;
        public string Title { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; }
        public CategoryEntity Category { get; set; }

        public static implicit operator GridCollectionItemViewModel(ProductEntity productmodel) 
        {
            var item = new GridCollectionItemViewModel
            {
                Id = productmodel.Id.ToString(),
                Title = productmodel.Name,
                Price = productmodel.Price,
                ImageUrl = productmodel.ImageUrl,
                Description = productmodel.Description,
                Category = productmodel.Category,

            }; return item;
        }

    }
}
