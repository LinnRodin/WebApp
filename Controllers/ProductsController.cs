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
            var allProducts = _context.Products.ToList();

            var viewModel = new ProductsIndexViewModel
            {
                AllProducts = new GridCollectionViewModel
                {
                    Title = "All Products",
                    GridCards = allProducts.Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Description = p.Description,
                        Category = p.Category.Name
                    }).Cast<GridCollectionItemViewModel>()
                        .ToList()
                }
            };

            return View(viewModel);
        }

    }
}

