using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;


namespace WebApp.Services;

public class ContactService
{
    private readonly DataContext _context;

    public ContactService(DataContext context)
    {
        _context = context;
    }

    // Metod för att lägga till en kontakt i databasen.
    public void AddContact(ContactsViewModel contactsViewModel)
    {   
        ContactEntity contactEntity = new ContactEntity()   // Skapar en ny instans av ContactEntity och fyller i kontaktinformationen från ContactsViewModel.
        {
            Name = contactsViewModel.Name,
            Email = contactsViewModel.Email,
            PhoneNumber = contactsViewModel.PhoneNumber,
            CompanyName = contactsViewModel.CompanyName,
            Message = contactsViewModel.Message
        };

        _context.Contacts.Add(contactEntity);   // Lägger till contactEntity i databasen genom att använda DbSet Add.
        _context.SaveChanges();                 // Sparar
    }
}
