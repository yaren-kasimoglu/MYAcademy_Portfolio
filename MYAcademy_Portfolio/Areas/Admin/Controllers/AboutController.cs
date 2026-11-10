using Microsoft.AspNetCore.Mvc;
using MYAcademy_Portfolio.Context;
using MYAcademy_Portfolio.Entities;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly PortfolioContext _context;

        public AboutController(PortfolioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _context.Abouts.ToList();

            return View(values);
        }

        [HttpGet]
        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAbout(About about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }

            _context.Abouts.Add(about);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var value = _context.Abouts.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            return View(value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateAbout(About model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var value = _context.Abouts.Find(model.AboutId);

            if (value == null)
            {
                return NotFound();
            }

            value.NameSurname = model.NameSurname;
            value.JobTitle = model.JobTitle;
            value.Location = model.Location;
            value.Expert = model.Expert;
            value.Email = model.Email;
            value.Description = model.Description;
            value.OpenToWork = model.OpenToWork;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);

            if (value == null)
            {
                return NotFound();
            }

            _context.Abouts.Remove(value);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
