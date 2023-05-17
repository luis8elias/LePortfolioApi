namespace LePortfolioApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public List<Image> Images { get; set; } = default!;

        public List<ProjectSkill> Technologies { get; set; } = default!;

        public List<Link> Links { get; set; } = default!;
    }
}
