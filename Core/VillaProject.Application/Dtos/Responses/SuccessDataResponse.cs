namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessDataResponse : Response
    {
        public object? Data { get; set; }

        public static SuccessDataResponse Success(object data, int statusCode)
        {
            return new SuccessDataResponse { Data = data, StatusCode = statusCode };
        }
    }
}
