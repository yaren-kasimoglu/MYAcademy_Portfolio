
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_Portfolio.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Proje adı zorunludur.")]
        [StringLength(150, ErrorMessage = "Proje adı en fazla 150 karakter olabilir.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Proje açıklaması zorunludur.")]
        [StringLength(2000, ErrorMessage = "Açıklama en fazla 2000 karakter olabilir.")]
        public string Description { get; set; } = string.Empty;

        public string? GithubUrl { get; set; }

        public string? CoverImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
