
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;

namespace MYAcademy_Portfolio.ViewComponents
{
    [ViewComponent(Name = "_DefaultSkillComponentPartial")]
    public class _DefaultSkillComponentPartial : ViewComponent
    {
        private readonly PortfolioContext _context;

        public _DefaultSkillComponentPartial(PortfolioContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _context.SkillCategories
                .Include(x => x.Skills)
                .OrderBy(x => x.DisplayOrder)
                .ToListAsync();

            foreach (var category in values)
            {
                category.Skills = category.Skills
                    .OrderBy(x => x.DisplayOrder)
                    .ToList();
            }

            return View(values);
        }
    }
}
