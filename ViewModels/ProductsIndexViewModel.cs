namespace WebApp.ViewModels
{
    public class ProductsIndexViewModel
    {
        public string Title { get; set; } = "All Products";
        public GridCollectionViewModel AllProducts { get; set; } = null!;
        public GridCollectionViewModel NewProducts { get; set; } = null!;
        public GridCollectionViewModel PopularProducts { get; set; } = null!;
        public GridCollectionViewModel FeaturedProducts { get; set; } = null!;
    }
}
