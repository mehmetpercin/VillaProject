namespace VillaProject.Application.Dtos.Responses
{
    public class ErrorResponse : Response<object>
    {
        public List<string> Errors { get; set; }

        public static ErrorResponse Fail(List<string> errors, int statusCode)
        {
            return new ErrorResponse { Errors = errors, StatusCode = statusCode };
        }

        public static ErrorResponse Fail(string error, int statusCode)
        {
            return new ErrorResponse { Errors = new List<string> { error }, StatusCode = statusCode };
        }
    }
}
