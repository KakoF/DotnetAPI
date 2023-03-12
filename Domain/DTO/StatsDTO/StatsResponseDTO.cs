using System.Text.Json.Serialization;

namespace Domain.DTO.StatsDTO
{
    public class StatsResponseDTO
    {
        public StatsResponseDTO(decimal countSimianDna, decimal countHumanDna, decimal ratio)
        {
            CountSimianDna = countSimianDna;
            CountHumanDna = countHumanDna;
            Ratio = ratio;
        }

        [JsonPropertyName("count_simian_dna")]
        public decimal CountSimianDna { get; set; }
        [JsonPropertyName("count_human_dna")]
        public decimal CountHumanDna { get; set; }
        [JsonPropertyName("ratio")]
        public decimal Ratio { get; set; }

    }
}
