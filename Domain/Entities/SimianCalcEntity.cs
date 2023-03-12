using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SimianCalcEntity
    {
        public DateTime Id { get; private set; }
        public DateTime? CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public decimal Total { get; private set; }
        public decimal CountIsSimian { get; private set; }
        public decimal CountIsHuman { get; private set; }
        public decimal IsSimianPercent { get; private set; }
        public decimal IsHumanPercent { get; private set; }
        public decimal Ratio { get; private set; }

        public SimianCalcEntity(DateTime id, decimal total, decimal countIsSimian, decimal countIsHuman, decimal isSimianPercente, decimal isHumanPercente, decimal ratio, DateTime? createdAt, DateTime? updatedAt)
        {
            Id = id; 
            Total = total;
            CountIsSimian = countIsSimian;
            CountIsHuman = countIsHuman;
            IsSimianPercent = isSimianPercente;
            IsHumanPercent = isHumanPercente;
            Ratio = ratio;
            CreatedAt= createdAt;
            UpdatedAt= updatedAt;

        }
    }
}
