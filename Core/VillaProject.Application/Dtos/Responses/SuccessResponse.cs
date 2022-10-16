namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessResponse : Response
    {
        public static SuccessResponse Success(int statusCode)
        {
            return new SuccessResponse { StatusCode = statusCode };
        }
    }
}
