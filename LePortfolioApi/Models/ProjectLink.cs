namespace LePortfolioApi.Models
{
    public class ProjectLink
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int LinkId { get; set; }

        public virtual Project Project { get; set; } = default!;

        public virtual Link Link { get; set; } = default!;
    }
}
