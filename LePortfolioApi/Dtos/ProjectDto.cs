using LePortfolioApi.Models;

namespace LePortfolioApi.Dtos
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public List<ImageDto> Images { get; set; } = default!;

        public  List<SkillDto> Technologies { get; set; } = default!;

        public  List<LinkDto> Links { get; set; } = default!;
    }

    public class SkillDto
    {
        public string Label { get; set; } = default!;
        public string Icon { get; set; } = default!;
    }
}
