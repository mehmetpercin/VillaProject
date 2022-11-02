namespace VillaProject.Application.Dtos.Responses
{
    public class ErrorResult : Result
    {
        public string Error { get; set; }

        public static ErrorResult Fail(string error, int statusCode)
        {
            return new ErrorResult { Error = error, StatusCode = statusCode };
        }
    }
}
