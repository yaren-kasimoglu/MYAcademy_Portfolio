using Microsoft.AspNetCore.Mvc;
using MYAcademy_Portfolio.Context;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly PortfolioContext _context;

        public MessageController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
            var values=_context.Messages.ToList();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            var value=_context.Messages.Find(id);

            return View(value);
        }
    }
}
