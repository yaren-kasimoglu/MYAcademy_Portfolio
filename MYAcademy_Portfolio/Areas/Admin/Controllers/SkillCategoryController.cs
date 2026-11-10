
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillCategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillCategoryController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> SkillCategoryList()
        {
            var values = await _context.SkillCategories
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            return View(values);
        }
        [HttpGet]
        public IActionResult CreateSkillCategory()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSkillCategory(
            SkillCategory category)
        {
            if (!ModelState.IsValid)
                return View(category);

            _context.SkillCategories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("SkillCategoryList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSkillCategory(int id)
        {
            var value = await _context.SkillCategories.FindAsync(id);

            if (value == null)
                return NotFound();

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkillCategory(
            SkillCategory category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var value = await _context.SkillCategories
                .FindAsync(category.SkillCategoryId);

            if (value == null)
                return NotFound();

            value.Name = category.Name;
            value.Description = category.Description;
            value.Icon = category.Icon;
            value.Color = category.Color;
            value.DisplayOrder = category.DisplayOrder;

            await _context.SaveChangesAsync();

            return RedirectToAction("SkillCategoryList");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkillCategory(int id)
        {
            var value = await _context.SkillCategories
                .Include(x => x.Skills)
                .FirstOrDefaultAsync(x => x.SkillCategoryId == id);

            if (value == null)
                return NotFound();

            if (value.Skills.Any())
            {
                TempData["Error"] =
                    "Bu kategoriye bağlı yetenekler bulunduğu için silinemez.";

                return RedirectToAction("SkillCategoryList");
            }

            _context.SkillCategories.Remove(value);
            await _context.SaveChangesAsync();

            return RedirectToAction("SkillCategoryList");
        }
    }
}
