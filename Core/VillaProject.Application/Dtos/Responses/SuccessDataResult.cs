namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessDataResult : Result
    {
        public object? Data { get; set; }

        public static SuccessDataResult Success(object data, int statusCode)
        {
            return new SuccessDataResult { Data = data, StatusCode = statusCode };
        }
    }
}
