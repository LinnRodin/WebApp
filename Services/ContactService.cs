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

    public void AddContact(ContactsViewModel contactsViewModel)
    {
        ContactEntity contactEntity = new ContactEntity()
        {
            Name = contactsViewModel.Name,
            Email = contactsViewModel.Email,
            PhoneNumber = contactsViewModel.PhoneNumber,
            CompanyName = contactsViewModel.CompanyName,
            Message = contactsViewModel.Message
        };

        _context.Contacts.Add(contactEntity);
        _context.SaveChanges();
    }
}
