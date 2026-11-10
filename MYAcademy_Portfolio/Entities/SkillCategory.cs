
namespace MYAcademy_Portfolio.Entities
{
    public class SkillCategory
    {
        public int SkillCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public int DisplayOrder { get; set; }

        public List<Skill> Skills { get; set; } = new();
    }
}
