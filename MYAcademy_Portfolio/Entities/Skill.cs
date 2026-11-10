
namespace MYAcademy_Portfolio.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public int SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}
