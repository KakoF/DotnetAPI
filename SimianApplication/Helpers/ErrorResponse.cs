using Newtonsoft.Json;

namespace SimianApplication.Helpers
{
    public class ErrorResponse
    {
        public int StatusCode { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object? Errors { get; }
        public ErrorResponse(int statusCode, string? message = null, object? arrayMessage = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
            Errors = arrayMessage;
        }
        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 401:
                    return "Não autorizado (não autenticado)";
                case 404:
                    return "Recurso não encontrado";
                case 405:
                    return "Método não permitido";
                case 500:
                    return "Erro interno no servidor";
                default:
                    return null;
            }
        }
    }
}
