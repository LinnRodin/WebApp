using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class RegisterViewModel
{
    [Display(Name = "Firstname")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Lastname")]
    public string LastName { get; set; } = null!;

    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Companyname")]
    public string? CompanyName { get; set; } 

    [Display(Name = "Password")]
    public string Password { get; set; } = null!;

    [Display(Name = "Confirm Password")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "Phonenumber")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Streetname")]
    public string? StreetName { get; set; }

    [Display(Name = "Postalcode")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [Display(Name = "Image")]
    public string? Image { get; set; }

    [Display(Name = "Message")]
    public string? Message { get; set; }

}
