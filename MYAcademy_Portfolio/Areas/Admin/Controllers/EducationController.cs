
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EducationController : Controller
    {
        private readonly PortfolioContext _context;

        public EducationController(PortfolioContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> EducationList()
        {
            var values = await _context.Educations.ToListAsync();
            return View(values);
        }


        [HttpGet]
        public IActionResult CreateEducation()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();

            return RedirectToAction("EducationList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateEducation(int id)
        {
            var value = await _context.Educations.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEducation(Education education)
        {
            if (!ModelState.IsValid)
            {
                return View(education);
            }

            var value = await _context.Educations
                .FindAsync(education.EducationId);

            if (value == null)
            {
                return NotFound();
            }

            value.Title = education.Title;
            value.SubTitle = education.SubTitle;
            value.Description = education.Description;
            value.Duration = education.Duration;

            await _context.SaveChangesAsync();

            return RedirectToAction("EducationList");
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEducation(int id)
        {
            var value = await _context.Educations.FindAsync(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.Educations.Remove(value);
            await _context.SaveChangesAsync();

            return RedirectToAction("EducationList");
        }
    }
}
