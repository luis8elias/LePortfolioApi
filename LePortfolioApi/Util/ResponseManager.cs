
using Microsoft.AspNetCore.Mvc;


namespace LePortfolioApi.Util
{
    public class ResponseManager
    {
        public static ActionResult Error(Exception e)
        {
            return new BadRequestObjectResult(new BasicResponse
            {
                Message = e.Message,
                Success = false,
            });
        }

        public static ActionResult OK(string message, object? response)
        {

            return new OkObjectResult(new BasicResponse<object>
            {
                Message = message,
                Success = true,
                Model = response
            });
        }

        public static ActionResult NotFound(string message)
        {
            return new NotFoundObjectResult( new BasicResponse
            {
                Message = message,
                Success = false,
            });
        }

        public static ActionResult ErrorWithValidations(string message, object errors)
        {

            return new BadRequestObjectResult(new BasicResponse<object>
            {
                Message = message,
                Success = false,
                Model = errors

            });
        }

        public static ActionResult Created(string message, object? response)
        {

            return new ObjectResult(new BasicResponse<object>
            {
                Message = message,
                Success = true,
                Model = response

            }) { StatusCode = 201 };

        }

    } 
}
