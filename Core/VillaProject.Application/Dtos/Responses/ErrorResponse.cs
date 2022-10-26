namespace VillaProject.Application.Dtos.Responses
{
    public class ErrorResponse : Response
    {
        public string Error { get; set; }

        public static ErrorResponse Fail(string error, int statusCode)
        {
            return new ErrorResponse { Error = error, StatusCode = statusCode };
        }
    }
}
