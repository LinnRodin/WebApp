using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
           
            var viewModel = new ProductsIndexViewModel
            {
                AllProducts = new GridCollectionViewModel
                {
                    Title = "All Products",
                    GridCards = await _productService.GetAllProductsAsync()
                }
            };

            return View(viewModel);
        }



        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel
            {
                Id = Convert.ToInt32(product.Id),
                Name = product.Title,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                CategoryId = product.Category?.Id,
                RelatedDetailsList = await _productService.GetProductsAmountDetailsAsync(4) // Gets 4 products from list in ProductDetailsViewModel. 
                
            };

            return View(viewModel);
        }

    }
}

