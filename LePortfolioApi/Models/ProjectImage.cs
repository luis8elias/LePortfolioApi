namespace LePortfolioApi.Models
{
    public class ProjectImage
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public int ImageId { get; set; }

        public virtual Project Project { get; set; } = default!;

        public virtual Image Image { get; set; } = default!;
    }
}
