using LePortfolioApi.Dtos;
using LePortfolioApi.Util;
using Microsoft.AspNetCore.Mvc;

namespace LePortfolioApi.Validations
{
    public static class AppValidator
    {
        public static IActionResult MakeValidationResponse(ActionContext context)
        { 
            List<ValidationError> errors = new List<ValidationError>();

            foreach (var keyStateValuePair in context.ModelState)
            {
                errors.Add(new ValidationError()
                {
                    PropertyName= keyStateValuePair.Key,
                    Errors = keyStateValuePair.Value.Errors.Select(x=>x.ErrorMessage).AsEnumerable()

                });
            }

            return new BadRequestObjectResult(ResponseManager.ErrorWithValidations("Petición incorrecta", errors));
        }
    }
}
