using Domain.Abstractions;
using Domain.Interfaces.Services;

namespace Service.Services
{
    public class SimianPatternsExecute : ISimianPatternsExecute
    {
        private readonly IEnumerable<SimianPatternAbstract> _patterns;

        public SimianPatternsExecute(IEnumerable<SimianPatternAbstract> patterns)
        {
            _patterns = patterns;
        }

        public IEnumerable<bool[]> Execute(string[] dna)
        {
            foreach (var pattern in _patterns)
            {
                yield return pattern.CheckPattern(dna);
            }
                       
        }
    }
}
