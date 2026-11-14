
using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_Portfolio.Controllers
{
    public class CvController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public CvController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]

        [HttpGet]
        public IActionResult Download()
        {
            string filePath = Path.Combine(
                _environment.WebRootPath,
                "files",
                "cv",
                "Yaren_Kasimoglu_CV.pdf"
            );

            if (!System.IO.File.Exists(filePath))
                return NotFound("CV dosyası bulunamadı.");

            return PhysicalFile(
                filePath,
                "application/pdf",
                "Yaren_Kasimoglu_CV.pdf"
            );
        }

    }
}
