using WebApp.ViewModels;

namespace WebApp.Services;

public class ShowcaseService
{
    private ShowcaseViewModel showcase = new ShowcaseViewModel()
    {
        Ingress = "WELCOME TO BMERKETO SHOP",
        Title = "Exclusive Chair Gold Collection.",
        LinkContent = "SHOP NOW",
        LinkUrl = "/products",
        ImageUrl = "images/placeholders/Stol.png"
    };

    public ShowcaseViewModel GetLatestShowcase()
    { 
        return showcase; 
    }
}
