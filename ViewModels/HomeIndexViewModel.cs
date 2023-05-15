namespace WebApp.ViewModels
{
    public class HomeIndexViewModel
    {
        public string Title { get; set; } = "Home";
        public GridCollectionViewModel BestCollection { get; set; } = null!;
        public GridCollectionViewModel TopProducts { get; set; } = null!;
        public GridCollectionViewModel TopSellProducts { get; set; } = null!;
        public GridCollectionViewModel UpToSale { get; set; } = null!;




    }
}
