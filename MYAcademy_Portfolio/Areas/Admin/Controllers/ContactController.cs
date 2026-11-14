
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly PortfolioContext _context;

        public ContactController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact()
        {
            var value = await _context.Contacts
                .OrderBy(x => x.ContactId)
                .FirstOrDefaultAsync();

            if (value == null)
            {
                return View(new Contact());
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }

            var value = await _context.Contacts
                .OrderBy(x => x.ContactId)
                .FirstOrDefaultAsync();

            if (value == null)
            {
                _context.Contacts.Add(contact);
            }
            else
            {
                value.Description = contact.Description;
                value.Email = contact.Email;
                value.Linkedin = contact.Linkedin;
                value.Location = contact.Location;
                value.Github = contact.Github;
                value.SubDescription = contact.SubDescription;
            }

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "İletişim bilgileri başarıyla kaydedildi.";

            return RedirectToAction("UpdateContact");
        }
    }
}
