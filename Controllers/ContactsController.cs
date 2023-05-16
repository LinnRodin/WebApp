using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;
using WebApp.Services;


namespace WebApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService _contactService;

        public ContactsController(ContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactsViewModel contactsViewModel)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contactsViewModel);

                return RedirectToAction("Thank You");
            }

            return View(contactsViewModel);
        }

        public IActionResult ThankYou()
        {
            return View();
        }
    }
}





