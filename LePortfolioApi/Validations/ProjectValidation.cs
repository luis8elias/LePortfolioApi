using FluentValidation;
using LePortfolioApi.Models;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations
{
    public class ProjectValidation : AbstractValidator<ProjectParamDto>
    {
        public ProjectValidation()
        {
            RuleFor(project => project.Title).NotNull().NotEmpty();
            RuleFor(project => project.Description).NotNull().NotEmpty();
            RuleFor(project => project.SkillsIds).NotNull().NotEmpty();
            RuleFor(project => project.Images).NotNull().NotEmpty();
            RuleFor(project => project.Links).NotNull().NotEmpty();
        }
    
    }

}
