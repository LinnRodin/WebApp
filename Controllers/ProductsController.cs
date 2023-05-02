using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApp.ViewModels;
using WebApp.Models;
using WebApp.Contexts;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DataContext _context;

        public ProductsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var newProducts = _context.Products.Where(p => p.Category == "new").ToList();
            var popularProducts = _context.Products.Where(p => p.Category == "popular").ToList();
            var featuredProducts = _context.Products.Where(p => p.Category == "featured").ToList();

            var viewModel = new ProductsIndexViewModel
            {
                NewProducts = new GridCollectionViewModel
                {
                    Title = "New Products",
                    GridCards = newProducts.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Category = p.Category
                    }).Cast<GridCollectionItemViewModel>()
                        .ToList()
                },
                PopularProducts = new GridCollectionViewModel
                {
                    Title = "Popular Products",
                    GridCards = popularProducts.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Category= p.Category
                    }).Cast<GridCollectionItemViewModel>()
                        .ToList()
                },
                FeaturedProducts = new GridCollectionViewModel
                {
                    Title = "Featured Products",
                    GridCards = featuredProducts.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Category= p.Category
                    }).Cast<GridCollectionItemViewModel>()
                        .ToList()
                }
            };

            return View(viewModel);
        }
    }
}

