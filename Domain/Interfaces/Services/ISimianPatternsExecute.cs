
namespace Domain.Interfaces.Services
{
    public interface ISimianPatternsExecute
    {
        IEnumerable<bool[]> Execute(string[] dna);
    }
}
