using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class ProfileEntity 
{
    [Key]
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; }
    public string? StreetName { get; set; } 
    public string? PostalCode { get; set; }
    public string? City { get; set; } 
    public string? CompanyName { get; set; }
    public string? Message { get; set; }


    
    public UserEntity User { get; set; } = null!;

}
