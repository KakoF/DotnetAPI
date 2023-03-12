using Domain.Interfaces.Services;
using System.Text.RegularExpressions;

namespace Domain.Abstractions
{
    public abstract class SimianPatternAbstract : ISimianPattern
    {
        protected readonly Regex DefaultPattern;

        public SimianPatternAbstract()
        {
            DefaultPattern = new Regex(@"(a{4}|c{4}|t{4}|g{4})", RegexOptions.IgnoreCase);
        }

        public abstract bool[] CheckPattern(string[] dna);

    }
}

