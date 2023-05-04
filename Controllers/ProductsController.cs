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
                        Description = p.Description
                    }).Cast<GridCollectionItemViewModel>()
                        .ToList()
                }
            };

            return View(viewModel);
        }


        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description
            };

            return View(viewModel);
        }


    }
}

