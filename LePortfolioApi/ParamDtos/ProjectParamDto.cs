namespace LePortfolioApi.ParamDtos
{
    public class ProjectParamDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;

        public List<int> SkillsIds { get; set; } = default!;

        public List<ProjectLinkParamDto> Links { get; set; } = default!;

        public List<ProjectImageParamDto> Images { get; set; } = default!;
    }
}
