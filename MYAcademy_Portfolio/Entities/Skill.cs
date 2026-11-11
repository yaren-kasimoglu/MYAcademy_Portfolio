
using System.ComponentModel.DataAnnotations;

namespace MYAcademy_Portfolio.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public int SkillCategoryId { get; set; }

        [Range(0, 100, ErrorMessage = "Yetenek seviyesi 0 ile 100 arasında olmalıdır.")]
        public int LevelPercentage { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
