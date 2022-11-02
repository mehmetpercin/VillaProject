using System.Text.Json.Serialization;

namespace VillaProject.Application.Dtos.Responses
{
    public class Result
    {
        [JsonIgnore]
        public int StatusCode { get; protected set; }
    }
}
