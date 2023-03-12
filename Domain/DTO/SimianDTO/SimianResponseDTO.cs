
namespace Domain.DTO.SimianDTO
{
    public class SimianResponseDTO
    {
        public SimianResponseDTO(int id, string dna, bool isSimian)
        {
            Id = id;
            Dna = dna;
            IsSimian = isSimian;
        }

        public int Id { get; set; }
        public string Dna { get; set; }
        public bool IsSimian { get; set; }
    }
}
