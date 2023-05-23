using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class ProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }
        // Hämtar alla produkter med tillhörande kategori och konverterar dem till en lista av GridCollectionItemViewModel.
        public async Task<List<GridCollectionItemViewModel>> GetAllProductsAsync()
        {
            var products = await _context.Products
                .Include(p => p.Category) 
                .Cast<GridCollectionItemViewModel>()
                .ToListAsync();

            return products;
        }

        // Hämtar ett angivet antal produkter av en viss kategori med tillhörande kategori och konverterar dem till en lista av GridCollectionItemViewModel.
        public async Task<List<GridCollectionItemViewModel>> GetProductsAmountByCategoryAsync(string categoryName, int numberOfProducts)
        {
                 var Products = await _context.Products
                .Where(p => p.Category.Name == categoryName)
                .Cast<GridCollectionItemViewModel>()
                .Take(numberOfProducts)
                .ToListAsync();

                    return Products;
        }

        // Hämtar ett angivet antal produkter med tillhörande kategori och konverterar dem till en lista av GridCollectionItemViewModel.
        public async Task<List<GridCollectionItemViewModel>> GetProductsAmountDetailsAsync( int numberOfProducts)
        {
            var Products = await _context.Products
           .Cast<GridCollectionItemViewModel>()
           .Take(numberOfProducts)
           .ToListAsync();

            return Products;
        }

        // Hämtar en produkt med en specifik ID och tillhörande kategori som en GridCollectionItemViewModel.
        public async Task<GridCollectionItemViewModel> GetProductByIdAsync(int id)
        {
            var product = await _context.Products

                .Where(p => p.Id == id)
                .Include(p => p.Category)
                .FirstOrDefaultAsync();

            return product;
        }


        // Uppdaterar en produkt via specifikt ID.
        public async Task UpdateProductAsync(int id, GridCollectionItemViewModel updatedProduct)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                
                return;
            }

            if (updatedProduct != null) 
            {
                product.Name = updatedProduct.Title;
                product.Price = updatedProduct.Price;
                product.Description = updatedProduct.Description;
                product.ImageUrl = updatedProduct.ImageUrl;
            }

            await _context.SaveChangesAsync();
        }


        // Tar bort en produkt via specifikt ID.
        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
