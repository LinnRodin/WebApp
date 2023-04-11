using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ShowcaseService
{
    private readonly List<ShowcaseModel> _showcases = new()
    {
        new ShowcaseModel()
        {
            Ingress = "WELCOME TO BMERKETO SHOP",
            Title = "Exclusive Chair Gold Collection.",
            ImageUrl = "images/placeholders/Stol.png",
            Button = new LinkButtonModel
            {
                Content = "SHOP NOW",
                Url = "/products",
            }
        }

    };

    public ShowcaseModel GetLatestShowcase()
    {
        return _showcases.LastOrDefault()!;
    }
}
