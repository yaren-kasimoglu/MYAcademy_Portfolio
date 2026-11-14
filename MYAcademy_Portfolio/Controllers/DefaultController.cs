
using Microsoft.AspNetCore.Mvc;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        private readonly PortfolioContext _context;

        public DefaultController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(
            [Bind("NameSurname,Email,Subject,MessageDetail")] Message message)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] =
                    "Lütfen tüm alanları doğru şekilde doldurunuz.";

                return RedirectToAction("Index", "Default",
                    new { area = "", section = "contact" });
            }

            message.SendDate = DateTime.Now;
            message.IsRead = false;

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] =
                "Mesajınız başarıyla gönderildi!";

            return RedirectToAction("Index", "Default",
                new { area = "", section = "contact" });
        }
    }
}
