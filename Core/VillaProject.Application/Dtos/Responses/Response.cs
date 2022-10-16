using System.Text.Json.Serialization;

namespace VillaProject.Application.Dtos.Responses
{
    public class Response
    {
        [JsonIgnore]
        public int StatusCode { get; protected set; }
    }
}
