using FluentValidation;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations
{
    public class ProjectLinkValidation : AbstractValidator<ProjectLinkParamDto>
    {
        public ProjectLinkValidation()
        {
            RuleFor(pLink => pLink.Value).NotNull().NotEmpty();
        }
    }
}
