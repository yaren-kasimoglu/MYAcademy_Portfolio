
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly PortfolioContext _context;

        public CategoryController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToListAsync();

            return View(values);
        }


        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return RedirectToAction("CategoryList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _context.Categories.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            var value = await _context.Categories.FindAsync(category.CategoryId);

            if (value == null)
            {
                return NotFound();
            }

            value.CategoryName = category.CategoryName;

            await _context.SaveChangesAsync();

            return RedirectToAction("CategoryList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .Include(x => x.Projects)
                .FirstOrDefaultAsync(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            if (category.Projects.Any())
            {
                TempData["ErrorMessage"] =
                    "Bu kategoriye bağlı projeler bulunduğu için silinemez.";

                return RedirectToAction("CategoryList");
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";

            return RedirectToAction("CategoryList");
        }

    }
}
