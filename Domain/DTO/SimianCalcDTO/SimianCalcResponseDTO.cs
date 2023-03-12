
namespace Domain.DTO.SimianCalcDTO
{
    public class SimianCalcResponseDTO
    {
        public DateTime Id { get; private set; }
        public decimal Total { get; private set; }
        public decimal CountIsSimian { get; private set; }
        public decimal CountIsHuman { get; private set; }
        public decimal IsSimianPercent { get; private set; }
        public decimal IsHumanPercent { get; private set; }
        public decimal Ratio { get; private set; }

        public SimianCalcResponseDTO(DateTime id, decimal total, decimal countIsSimian, decimal countIsHuman, decimal isSimianPercent, decimal isHumanPercent, decimal ratio)
        {
            Id = id;
            Total = total;
            CountIsSimian = countIsSimian;
            CountIsHuman = countIsHuman;
            IsSimianPercent = isSimianPercent;
            IsHumanPercent = isHumanPercent;
            Ratio = ratio;

        }
    }
}
