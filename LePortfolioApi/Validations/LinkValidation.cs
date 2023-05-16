using FluentValidation;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations
{
    public class LinkValidation : AbstractValidator<LinkParamDto>
    {

      
       public LinkValidation()
       {
            RuleFor(skill => skill.Value).NotNull().NotEmpty();
            RuleFor(skill => skill.ProjectId).NotNull().NotEqual(0);
       }
        
    }
}
