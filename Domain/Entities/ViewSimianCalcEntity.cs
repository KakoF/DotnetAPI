namespace Domain.Entities
{
    public class ViewSimianCalcEntity
    {
        public ViewSimianCalcEntity(decimal total, decimal countIsSimian, decimal countIsHuman, decimal isSimianPercent, decimal isHumanPercent, decimal ratio)
        {
            Total = total;
            CountIsSimian = countIsSimian;
            CountIsHuman = countIsHuman;
            IsSimianPercent = isSimianPercent;
            IsHumanPercent = isHumanPercent;
            Ratio = ratio;
        }

        public decimal Total { get; private set; }
        public decimal CountIsSimian { get; private set; }
        public decimal CountIsHuman { get; private set; }
        public decimal IsSimianPercent { get; private set; }
        public decimal IsHumanPercent { get; private set; }
        public decimal Ratio { get; private set; }

    }
}
