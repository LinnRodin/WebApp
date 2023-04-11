using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ProductsIndexViewModel
            {
                AllProducts = new GridCollectionViewModel
                {
                    Title = "SHOP"
                }
            };
            return View(viewModel);
        }
    }
}
