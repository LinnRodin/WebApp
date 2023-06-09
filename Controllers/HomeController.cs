﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Contexts;
using WebApp.Services;
using WebApp.ViewModels;



public class HomeController : Controller
{
    private readonly ProductService _productService;
    private readonly DataContext _context;

    public HomeController(DataContext context, ProductService productService)
    {
        _context = context;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {

        var viewModel = new HomeIndexViewModel // Skapar en instans av HomeIndexViewModel som används som modell i vyn.
        {
            BestCollection = new GridCollectionViewModel  // Skapar en instans av GridCollectionViewModel för att visa "BestCollection" produkterna. 
            {
                Title = "Best Collection",
                Categories = new List<string> { "All", "Bags", "Dresses", "Decorations", "Essentials", "Interior", "Laptops", "Mobile", "MakeUp" },
                GridCards = await _productService.GetProductsAmountByCategoryAsync("Featured", 8)  // Hämtar ett visst antal produkter för den angivna kategorin "Featured" genom att anropa GetProductsAmountByCategoryAsync-metoden i ProductService.
            },

            UpToSale = new GridCollectionViewModel // Skapar en instans av GridCollectionViewModel för att visa "UpToSale" produkterna. 
            {
                Title = "UpToSale",
                GridCards = await _productService.GetProductsAmountByCategoryAsync("New", 3) // Hämtar ett visst antal produkter för den angivna kategorin "New" genom att anropa GetProductsAmountByCategoryAsync-metoden i ProductService.
            },

            TopSellProducts = new GridCollectionViewModel // Skapar en instans av GridCollectionViewModel för att visa "TopSellProducts" produkterna. 
            {
                Title = "TopSellProducts",
                GridCards = await _productService.GetProductsAmountByCategoryAsync("Popular", 7)
            },

            TopProducts = new GridCollectionViewModel  // Skapar en instans av GridCollectionViewModel för att visa "TopProducts" produkterna. 
            {
                Title = "TopProducts",
                GridCards = await _productService.GetProductsAmountByCategoryAsync("Popular", 3) // Hämtar ett visst antal produkter för den angivna kategorin "Popular" genom att anropa GetProductsAmountByCategoryAsync-metoden i ProductService.
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