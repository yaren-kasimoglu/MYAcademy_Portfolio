
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly PortfolioContext _context;

        public ProjectController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ProjectList()
        {
            var values = await _context.Projects
                .Include(x => x.Category)
                .OrderByDescending(x => x.ProjectId)
                .ToListAsync();

            return View(values);
        }



        [HttpGet]
        public async Task<IActionResult> CreateProject()
        {
            await LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(project);
            }

            project.IsActive = true;

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Proje başarıyla eklendi.";

            return RedirectToAction("ProjectList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProject(int id)
        {
            var project = await _context.Projects.FindAsync(id);

            if (project == null)
                return NotFound();

            await LoadCategories();

            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProject(
            int id,
            [Bind("ProjectId,Title,Description,GithubUrl,CoverImageUrl,CategoryId,IsActive")]
    Project project)
        {
            if (id != project.ProjectId)
                return BadRequest();

            var existingProject = await _context.Projects.FindAsync(id);

            if (existingProject == null)
                return NotFound();

            // Navigation property formdan gelmediği için
            // yalnızca düzenlenebilir alanları doğruluyoruz.
            ModelState.Remove(nameof(Project.Category));

            if (!ModelState.IsValid)
            {
                await LoadCategories();
                return View(project);
            }

            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.GithubUrl = project.GithubUrl;
            existingProject.CoverImageUrl = project.CoverImageUrl;
            existingProject.CategoryId = project.CategoryId;
            existingProject.IsActive = project.IsActive;

            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Proje başarıyla güncellendi.";

            return RedirectToAction("ProjectList");
        }



        private async Task LoadCategories()
        {
            var categories = await _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToListAsync();

            ViewBag.Categories = new SelectList(
                categories,
                "CategoryId",
                "CategoryName"
            );
        }

    }
}
