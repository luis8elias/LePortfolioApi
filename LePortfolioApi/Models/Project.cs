namespace LePortfolioApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual List<ProjectImage> Images { get; set; } = default!;

        public virtual List<ProjectSkill> Technologies { get; set; } = default!;

        public virtual List<ProjectLink> Links { get; set; } = default!;

    }
}
