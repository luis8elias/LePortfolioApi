using FluentValidation;
using LePortfolioApi.ParamDtos;

namespace LePortfolioApi.Validations
{
    public class ImageValidation : AbstractValidator<ImageParamDto>
    {


        public ImageValidation()
        {
            RuleFor(image => image.Url).NotNull().NotEmpty();
        }

    }
}
