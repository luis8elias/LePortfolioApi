using LePortfolioApi.Models;

namespace LePortfolioApi.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public virtual List<ImageDto> Images { get; set; } = default!;

        public virtual List<Skill> Technologies { get; set; } = default!;

        public virtual List<LinkDto> Links { get; set; } = default!;
    }
}
