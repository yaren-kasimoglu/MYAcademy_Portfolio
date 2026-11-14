
using Microsoft.AspNetCore.Mvc;

namespace MYAcademy_Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CvController : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public CvController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            string cvPath = Path.Combine(
                _environment.WebRootPath,
                "files", "cv", "cv.pdf"
            );

            ViewBag.CvExists = System.IO.File.Exists(cvPath);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadCv(IFormFile cvFile)
        {
            if (cvFile == null || cvFile.Length == 0)
            {
                TempData["ErrorMessage"] = "Lütfen bir PDF seçiniz.";
                return RedirectToAction("Index");
            }

            if (Path.GetExtension(cvFile.FileName)
                .ToLowerInvariant() != ".pdf")
            {
                TempData["ErrorMessage"] = "Yalnızca PDF yükleyebilirsiniz.";
                return RedirectToAction("Index");
            }

            if (cvFile.Length > 5 * 1024 * 1024)
            {
                TempData["ErrorMessage"] = "Dosya en fazla 5 MB olabilir.";
                return RedirectToAction("Index");
            }

            string folderPath = Path.Combine(
                _environment.WebRootPath,
                "files", "cv"
            );

            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "Yaren_Kasimoglu_CV.pdf");

            string tempPath = Path.Combine(
                folderPath,
                Guid.NewGuid().ToString("N") + ".tmp"
            );

            try
            {
                await using (var stream = new FileStream(
                    tempPath, FileMode.CreateNew))
                {
                    await cvFile.CopyToAsync(stream);
                }

                byte[] header = new byte[5];

                await using (var stream = new FileStream(
                    tempPath, FileMode.Open, FileAccess.Read))
                {
                    int bytesRead = await stream.ReadAsync(
                        header.AsMemory(0, 5)
                    );

                    if (bytesRead != 5 ||
                        System.Text.Encoding.ASCII.GetString(header)
                        != "%PDF-")
                    {
                        TempData["ErrorMessage"] =
                            "Geçerli bir PDF dosyası seçiniz.";

                        return RedirectToAction("Index");
                    }
                }

                System.IO.File.Move(
                    tempPath,
                    filePath,
                    overwrite: true
                );

                TempData["SuccessMessage"] =
                    "CV başarıyla güncellendi.";
            }
            finally
            {
                if (System.IO.File.Exists(tempPath))
                    System.IO.File.Delete(tempPath);
            }

            return RedirectToAction("Index");
        }
    }
}
