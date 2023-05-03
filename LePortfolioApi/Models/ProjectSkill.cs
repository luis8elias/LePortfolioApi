namespace LePortfolioApi.Models
{
    public class ProjectSkill
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int SkillId { get; set; }

        public virtual Project Project { get; set; } = default!;

        public virtual Skill Skill { get; set; } = default!;
    }
}
