
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Models;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly PortfolioContext _context;

        public DashboardController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalProjects = await _context.Projects.CountAsync(),
                ActiveProjects = await _context.Projects.CountAsync(p => p.IsActive),
                TotalSkills = await _context.Skills.CountAsync(),
                TotalExperiences = await _context.Experiences.CountAsync(),
                TotalEducations = await _context.Educations.CountAsync(),

                TotalMessages = await _context.Messages.CountAsync(),
                ReadMessages = await _context.Messages.CountAsync(m => m.IsRead),
                UnreadMessages = await _context.Messages.CountAsync(m => !m.IsRead),

                RecentMessages = await _context.Messages
                    .AsNoTracking()
                    .OrderByDescending(m => m.SendDate)
                    .ThenByDescending(m => m.MessageId)
                    .Take(5)
                    .ToListAsync(),

                RecentProjects = await _context.Projects
                    .AsNoTracking()
                    .Include(p => p.Category)
                    .OrderByDescending(p => p.ProjectId)
                    .Take(3)
                    .ToListAsync(),

                CategoryCounts = await _context.Categories
                    .AsNoTracking()
                    .Select(c => new CategoryProjectCountViewModel
                    {
                        CategoryName = c.CategoryName,
                        ProjectCount = c.Projects.Count()
                    })
                    .OrderByDescending(c => c.ProjectCount)
                    .ToListAsync()
            };

            return View(model);
        }
    }
}
