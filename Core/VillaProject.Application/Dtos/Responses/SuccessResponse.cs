namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessResponse : Response<object>
    {
        public static Response<object> Success(int statusCode)
        {
            return new SuccessResponse { StatusCode = statusCode };
        }
    }
}
