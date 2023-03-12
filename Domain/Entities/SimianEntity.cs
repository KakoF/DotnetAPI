
namespace Domain.Entities
{
    public class SimianEntity : BaseEntity
    {
        
        public SimianEntity(string dna, bool isSimian) : base()
        {
            Dna = dna;
            IsSimian = isSimian;
        }

        public SimianEntity(int id, string dna, bool isSimian, DateTime? createdAt, DateTime? updatedAt) :base(id, createdAt, updatedAt)
        {
            Dna = dna;
            IsSimian = isSimian;
        }

        public string Dna { get; private set; }
        public bool IsSimian{ get; private set; }
        
    }
}
