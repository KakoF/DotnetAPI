using Newtonsoft.Json;

namespace Domain.Models.Clients
{
    public class ClientResponseModel
    {
        public int StatusCode { get; set; }
        public object? Data { get; set; }

        public ClientResponseModel(int statusCode, string data)
        {
            StatusCode = statusCode;
            Data = JsonConvert.DeserializeObject<object>(data);
        }
        public ClientResponseModel(int statusCode, object? data = null)
        {
            StatusCode = statusCode;
            Data = data;
        }
    }
}
