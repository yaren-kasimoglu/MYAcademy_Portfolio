
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;

namespace MYAcademy_Portfolio.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultExperienceComponentPartial(PortfolioContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.Experiences
                .Where(x => x.IsActive == true) //sadece aktif olanlar görülmeli
                .OrderByDescending(x => x.ExperienceId)
                .ToListAsync();

            return View(values);
        }

    }
}
