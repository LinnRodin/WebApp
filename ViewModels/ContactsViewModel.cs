using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class ContactsViewModel
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Name")]
    [RegularExpression(@"^[a-zA-ZÅÄÖåäö\s'-]+$", ErrorMessage = "Invalid format. Only letters, ÅÄÖ, hyphen, apostrophe, and spaces allowed.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;

    [Display(Name = "Save my name and email in this browser for the next time I comment.")]
    public bool AcceptedData { get; set; }

    [Display(Name = "Phonenumber")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Companyname")]
    public string? CompanyName { get; set; }


    [Display(Name = "Message")]
    public string? Message { get; set; }
}
