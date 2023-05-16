using FluentValidation;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations
{
    public class ProjectImageValidation : AbstractValidator<ProjectImageParamDto>
    {
        public ProjectImageValidation()
        {
            RuleFor(pImage => pImage.Url).NotNull().NotEmpty();
        }
    }
}
