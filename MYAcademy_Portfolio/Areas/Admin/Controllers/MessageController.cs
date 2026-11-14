
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

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

        [HttpGet]
        public async Task<IActionResult> MessageList(
            string? search,
            string? sort,
            string? status)
        {
            var query = _context.Messages.AsNoTracking().AsQueryable();

            // Gönderici veya konuya göre arama
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();

                query = query.Where(x =>
                    x.NameSurname.Contains(search) ||
                    x.Subject.Contains(search));
            }

            // Okundu / okunmadı filtresi
            if (status == "read")
            {
                query = query.Where(x => x.IsRead);
            }
            else if (status == "unread")
            {
                query = query.Where(x => !x.IsRead);
            }

            // Tarihe göre sıralama
            query = sort == "oldest"
                ? query.OrderBy(x => x.SendDate)
                       .ThenBy(x => x.MessageId)
                : query.OrderByDescending(x => x.SendDate)
                       .ThenByDescending(x => x.MessageId);

            var messages = await query.ToListAsync();

            // Filtrelerden bağımsız toplam sayılar
            ViewBag.TotalMessageCount =
                await _context.Messages.CountAsync();

            ViewBag.UnreadMessageCount =
                await _context.Messages.CountAsync(x => !x.IsRead);

            ViewBag.Search = search;
            ViewBag.Sort = sort == "oldest" ? "oldest" : "newest";
            ViewBag.Status = status ?? "all";

            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> MessageDetail(int id)
        {
            var message = await _context.Messages
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.MessageId == id);

            if (message == null)
                return NotFound();

            return View(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //mesaj okundu kontrolü
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
                return NotFound();

            if (!message.IsRead)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }

            return Ok(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //mesajı okunmadı yapma kontrollü
        public async Task<IActionResult> MarkAsUnread(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
                return NotFound();

            message.IsRead = false;
            await _context.SaveChangesAsync();

            return Ok(new { success = true });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
                return NotFound();

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Mesaj başarıyla silindi.";

            return RedirectToAction("MessageList");
        }
    }
}
