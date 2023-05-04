using Microsoft.AspNetCore.Mvc;
using WebApp.Contexts;
using WebApp.ViewModels;



public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var BestCollection = _context.Products
            .Where(p => p.Category.Name == "Featured")
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description
                
            }).Take(8)
            .ToList();

        var UpToSale = _context.Products
            .Where(p => p.Category.Name == "New")
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description
                
            }).Take(3)
            .ToList();

        var TopSellProducts = _context.Products
            .Where(p => p.Category.Name == "Popular")
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description
                
            }).Take(7)
            .ToList();
      

        var TopProducts = _context.Products
            .Where(p => p.Category.Name == "New")
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ImageUrl = p.ImageUrl,
                Description = p.Description
                
            }).Take(3)
            .ToList();



        var NewProductsList = TopProducts.Concat(TopSellProducts).ToList();

        var viewModel = new HomeIndexViewModel
        {
            NewProducts = new GridCollectionViewModel
            {
                Title = "New Products",
                GridCards = NewProductsList.Cast<GridCollectionItemViewModel>().ToList()
            },
            PopularProducts = new GridCollectionViewModel
            {
                Title = "Popular Products",
                GridCards = UpToSale.Cast<GridCollectionItemViewModel>().ToList()
            },
            FeaturedProducts = new GridCollectionViewModel
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bags", "Dresses", "Decorations", "Essentials", "Interior", "Laptops", "Mobile", "MakeUp" },
                GridCards = BestCollection.Cast<GridCollectionItemViewModel>().ToList()
            }
        };


        return View(viewModel);
    }
}






























/*
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            var viewModel = new HomeIndexViewModel
            {
                BestCollection = new GridCollectionViewModel 
                { 
                    Title = "Best Collection", 
                    Categories = new List<string> { "All", "Bags", "Dresses", "Decorations", "Essentials", "Interior", "Laptops", "Mobile", "MakeUp" },
                    GridCards = new List<GridCollectionItemViewModel> 
                    { 
                       new GridCollectionItemViewModel { Id="1", Title = "Apple watch series", Price = 50, ImageUrl = "images/placeholders/Applewatch.png" },
                       new GridCollectionItemViewModel { Id="2", Title = "Apple watch series", Price = 30, ImageUrl = "images/placeholders/Tablelamp.png" },
                       new GridCollectionItemViewModel { Id="3", Title = "Apple watch series", Price = 80, ImageUrl = "images/placeholders/Laptop.png" },
                       new GridCollectionItemViewModel { Id="4", Title = "Apple watch series", Price = 30, ImageUrl = "images/placeholders/Gumshoes.png" },
                       new GridCollectionItemViewModel { Id="5", Title = "Apple watch series", Price = 45, ImageUrl = "images/placeholders/Applewatch.png" },
                       new GridCollectionItemViewModel { Id="6", Title = "Apple watch series", Price = 35, ImageUrl = "images/placeholders/Applewatch.png" },
                       new GridCollectionItemViewModel { Id="7", Title = "Apple watch series", Price = 25, ImageUrl = "images/placeholders/Applewatch.png" },
                       new GridCollectionItemViewModel { Id="8", Title = "Apple watch series", Price = 55, ImageUrl = "images/placeholders/Applewatch.png" }
                     
                    }
                }
                
            };

            return View(viewModel);
        }
    }
}

*/