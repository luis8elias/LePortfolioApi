using LePortfolioApi.Dtos;

namespace LePortfolioApi.Util
{
    public class ResponseManager
    {
        public static BasicResponse Error(Exception ex)
        {
            return new BasicResponse
            {
                Message = ex.Message,
                Success = false,
            };
        }
        public static BasicResponse BadRequest(string exception)
        {
            return new BasicResponse
            {
                Message = exception,
                Success = false,
            };
        }

        public static BasicResponse<object> OK(string message, object? response)
        {
            return new BasicResponse<object>
            {
                Message = message,
                Success = true,
                Model = response
            };
        }

        public static BasicResponse NotFound(string message)
        {
            return new BasicResponse
            {
                Message = message,
                Success = false,
            };
        }

        public static BasicResponse ErrorWithValidations(string message , object errors)
        {
            return new BasicResponse<object>
            {
                Message = message,
                Success = false,
                Model = errors
                
            };
        }

    } 
}
