﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class RegisterViewModel
{
    [Required(ErrorMessage = "Firstname is required")]
    [Display(Name = "Firstname")]
    [RegularExpression(@"^[a-zA-ZÅÄÖåäö'-]+$", ErrorMessage = "Invalid format. Only letters, ÅÄÖ, hyphen and apostrophe allowed.")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Lastname is required")]
    [Display(Name = "Lastname")]
    [RegularExpression(@"^[a-zA-ZÅÄÖåäö'-]+$", ErrorMessage = "Invalid format. Only letters, ÅÄÖ, hyphen and apostrophe allowed.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [Display(Name = "E-mail")]
    [DataType(DataType.EmailAddress)]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Password is required")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "You must Confirm Password")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = "The password does not match")]
    public string ConfirmPassword { get; set; } = null!;

    [Required(ErrorMessage = "You must accept the terms and agreements to proceed.")]
    public bool AcceptedTerms { get; set; }

    [Display(Name = "Company")]
    public string? CompanyName { get; set; }

    [Display(Name = "Mobile")]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Streetname")]
    public string? StreetName { get; set; }

    [Display(Name = "Postalcode")]
    public string? PostalCode { get; set; }

    [Display(Name = "City")]
    public string? City { get; set; }

    [DataType(DataType.Upload)]
    [Display(Name = "Upload Image")]
    public IFormFile? Image { get; set; }

    [Display(Name = "Message")]
    public string? Message { get; set; }



    public static implicit operator IdentityUser(RegisterViewModel registerViewModel)
    {

        return new IdentityUser
        {
            UserName = registerViewModel.Email,
            Email = registerViewModel.Email, 
            PhoneNumber = registerViewModel.PhoneNumber,
        };

    }

    public static implicit operator UserProfileEntity (RegisterViewModel registerViewModel)
    {
        return new UserProfileEntity 
        {   
            
            FirstName = registerViewModel.FirstName,
            LastName = registerViewModel.LastName,
            StreetName = registerViewModel.StreetName,
            PostalCode = registerViewModel.PostalCode,
            City = registerViewModel.City,
            Message = registerViewModel.Message

        };

        



    }

}
