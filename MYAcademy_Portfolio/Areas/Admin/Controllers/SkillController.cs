
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SkillController : Controller
    {
        private readonly PortfolioContext _context;

        public SkillController(PortfolioContext context)
        {
            _context = context;
        }

      [HttpGet]
        public async Task<IActionResult> SkillList()
        {
            var values = await _context.Skills
                .Include(x => x.SkillCategory)
                .OrderBy(x => x.SkillCategory.DisplayOrder)
                .ThenBy(x => x.DisplayOrder)
                .ToListAsync();

            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateSkill()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSkill(Skill skill)
        {
            ModelState.Remove(nameof(Skill.SkillCategory));

            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(skill);
            }

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSkill(int id)
        {
            var value = await _context.Skills.FindAsync(id);

            if (value == null)
                return NotFound();

            await LoadCategories();
            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateSkill(Skill skill)
        {
            ModelState.Remove(nameof(Skill.SkillCategory));

            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(skill);
            }

            var value = await _context.Skills
                .FindAsync(skill.SkillId);

            if (value == null)
                return NotFound();

            value.Name = skill.Name;
            value.DisplayOrder = skill.DisplayOrder;
            value.SkillCategoryId = skill.SkillCategoryId;
            value.LevelPercentage = skill.LevelPercentage;

            await _context.SaveChangesAsync();

            return RedirectToAction("SkillList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            var value = await _context.Skills.FindAsync(id);

            if (value == null)
                return NotFound();

            _context.Skills.Remove(value);
            await _context.SaveChangesAsync();

            return RedirectToAction("SkillList");
        }
        //category için dropdown
        private async Task LoadCategories()
        {
            var categories = await _context.SkillCategories
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            ViewBag.Categories = new SelectList(
                categories,
                "SkillCategoryId",
                "Name"
            );
        }
    }
}
