
using FluentValidation;
using LePortfolioApi.Models;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations;

public class SkillValidator : AbstractValidator<SkillParamDto>
{
    public SkillValidator()
    {
        RuleFor(skill => skill.Label).NotNull().NotEmpty();
        RuleFor(skill => skill.Icon).NotNull().NotEmpty();
    }
}