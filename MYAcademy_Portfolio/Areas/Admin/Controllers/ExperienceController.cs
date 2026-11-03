using Microsoft.AspNetCore.Mvc;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExperienceController : Controller
    {

        private readonly PortfolioContext _context;

        public ExperienceController(PortfolioContext context)
        {
            _context = context;
        }

        public IActionResult ExperienceList()
        {
            var values=_context.Experiences.ToList();

            return View(values);
        }


        [HttpGet]
        public IActionResult CreateExperience()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateExperience(Experience experience)
        {
         _context.Experiences.Add(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = _context.Experiences.Find(id);
            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteExperience(int id)
        {
            var value = _context.Experiences.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.Experiences.Remove(value);
            _context.SaveChanges();

            return RedirectToAction("ExperienceList");
        }

    }
}
