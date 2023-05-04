namespace WebApp.ViewModels
{
    public class ProductsIndexViewModel
    {
        public string Title { get; set; } = "All Products";
        public GridCollectionViewModel AllProducts { get; set; } = null!;
        
    }
}
