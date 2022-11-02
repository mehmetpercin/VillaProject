namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessResult : Result
    {
        public static SuccessResult Success(int statusCode)
        {
            return new SuccessResult { StatusCode = statusCode };
        }
    }
}
