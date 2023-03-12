using Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Service.Implementations
{
    public class HorizontalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<HorizontalSimianPattern> _logger;
        public HorizontalSimianPattern(ILogger<HorizontalSimianPattern> logger) : base()
        {
            _logger = logger;
        }

        public override bool[] CheckPattern(string[] dna)
        {
            bool[] isSimian = new bool[dna.Length];
            foreach (var row in dna.Select((value, index) => new { index, value }))
                isSimian[row.index] = DefaultPattern.IsMatch(row.value);

            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna), isSimian.Select(x => x));
            return isSimian;
        }
    }
}
