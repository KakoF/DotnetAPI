using System.Text.Json.Serialization;

namespace Domain.DTO.IsSimianDTO
{
    public class IsSimianResponseDTO
    {
        [JsonPropertyName("is_simian")]
        public bool IsSimian { get; set; }

        public IsSimianResponseDTO(bool isSimimian)
        {
            IsSimian = isSimimian;
        }

    }
}
