using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MYAcademy_Portfolio.Context;

public class _DefaultEducationComponentPartial : ViewComponent
{
    private readonly PortfolioContext _context;

    public _DefaultEducationComponentPartial(PortfolioContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var values = await _context.Educations
            .OrderByDescending(x => x.EducationId)
            .ToListAsync();

        return View(values);
    }
}