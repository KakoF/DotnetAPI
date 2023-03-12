using Domain.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace Service.Implementations
{
    public class VerticalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<VerticalSimianPattern> _logger;
        public VerticalSimianPattern(ILogger<VerticalSimianPattern> logger) : base()
        {
            _logger = logger;
        }

        public override bool[] CheckPattern(string[] dna)
        {
            bool[] isSimian = new bool[dna.Length];
            foreach (var step in dna.Select((value, index) => new { index, value }))
            {
                string joinedDna = string.Join("", dna.Select(s => string.IsNullOrEmpty(s) ? "" : s.Substring(step.index, 1)));
                isSimian[step.index] = DefaultPattern.IsMatch(joinedDna);

            }
            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", dna), isSimian.Select(x => x));
            return isSimian;
        }
    }
}
