namespace VillaProject.Application.Dtos.Responses
{
    public class ErrorResponse : Response<object>
    {
        public List<string> Errors { get; set; }

        public static Response<object> Fail(List<string> errors, int statusCode)
        {
            return new ErrorResponse { Errors = errors, StatusCode = statusCode };
        }

        public static Response<object> Fail(string error, int statusCode)
        {
            return new ErrorResponse { Errors = new List<string> { error }, StatusCode = statusCode };
        }
    }
}
