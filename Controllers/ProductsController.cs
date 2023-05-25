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
                    GridCards = await _productService.GetAllProductsAsync()  // Hämtar alla produkter genom att anropa GetAllProductsAsync-metoden i ProductService.
                }
            };

            return View(viewModel);
        }



        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id); // Hämtar produkten via id:et genom att anropa GetProductByIdAsync-metoden i ProductService.

            if (product == null)
            {
                return NotFound();
            }

            var viewModel = new ProductDetailsViewModel // Skapar en instans av ProductDetailsViewModel för att visa detaljer om produkten.
            {
                Id = Convert.ToInt32(product.Id),
                Name = product.Title,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                CategoryId = product.Category?.Id,
                Category = product.Category,
                RelatedDetailsList = await _productService.GetProductsAmountDetailsAsync(4) // Hämtar en lista med relaterade produktdetaljer genom att anropa GetProductsAmountDetailsAsync-metoden i ProductService. 
                                                                                           //Om jag vill ha en allmän metod som jag skall kunna hämta ut olika antal ifrån till en vy tar jag bara bort 4 och kör Take i vyn (Detailsvyn i detta fall) 
            };

            return View(viewModel);
        }

    }
}

