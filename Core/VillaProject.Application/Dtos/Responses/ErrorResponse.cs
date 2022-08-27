namespace VillaProject.Application.Dtos.Responses
{
    public class ErrorResponse<T> : Response<T>
    {
        public List<string> Errors { get; set; }

        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new ErrorResponse<T> { Errors = errors, StatusCode = statusCode };
        }

        public static Response<T> Fail(string error, int statusCode)
        {
            return new ErrorResponse<T> { Errors = new List<string> { error }, StatusCode = statusCode };
        }
    }
}
