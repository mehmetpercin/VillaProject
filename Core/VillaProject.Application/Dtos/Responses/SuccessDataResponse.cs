namespace VillaProject.Application.Dtos.Responses
{
    public class SuccessDataResponse<T> : Response<T>
    {
        public T Data { get; set; }

        public static SuccessDataResponse<T> Success(T data, int statusCode)
        {
            return new SuccessDataResponse<T> { Data = data, StatusCode = statusCode };
        }
    }
}
