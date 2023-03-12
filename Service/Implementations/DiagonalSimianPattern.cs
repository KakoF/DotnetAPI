using Domain.Abstractions;
using Microsoft.Extensions.Logging;

namespace Service.Implementations
{
    public class DiagonalSimianPattern : SimianPatternAbstract
    {
        private readonly ILogger<DiagonalSimianPattern> _logger;
        public DiagonalSimianPattern(ILogger<DiagonalSimianPattern> logger) : base()
        {
            _logger = logger;
        }

        private List<string> ParseDiagonalArray(string[,] newArray, int arrayLength)
        {
            List<string> newSimianList = new List<string>();

            for (int col = 0; col < arrayLength; col++)
            {
                string diagonalPattern = "";
                int startcol = col, startrow = 0;
                while (startcol >= 0 && startrow < arrayLength)
                {
                    diagonalPattern += (newArray[startrow, startcol]);
                    startcol--;
                    startrow++;
                }

                newSimianList.Add(diagonalPattern);
            }

            for (int row = 1; row < arrayLength; row++)
            {
                string diagonalPattern = "";
                int startrow = row, startcol = arrayLength - 1;
                while (startrow < arrayLength && startcol >= 0)
                {
                    diagonalPattern += (newArray[startrow, startcol]);
                    startcol--;
                    startrow++;
                }
                newSimianList.Add(diagonalPattern);
            }

            return newSimianList;
        }

        private List<string> ParseDiagonalReverseArray(string[,] newArray, int arrayLength)
        {
            List<string> newSimianList = new List<string>();

            for (int col = 0; col < arrayLength; col++)
            {
                string diagonalPattern = "";
                int startcol = col, startrow = arrayLength;
                while (startcol >= 0 && startrow >= 0)
                {
                    diagonalPattern += (newArray[startrow - 1, startcol]);
                    startcol--;
                    startrow--;
                }

                newSimianList.Add(diagonalPattern);
            }
            for (int row = arrayLength - 2; row >= 0; row--)
            {
                string diagonalPattern = "";
                int startrow = row, startcol = arrayLength - 1;
                while (startrow >= 0 && startcol > 0)
                {
                    diagonalPattern += (newArray[startrow, startcol]);
                    startcol--;
                    startrow--;
                }
                newSimianList.Add(diagonalPattern);
            }
            return newSimianList;
        }

        private string[] ParseDiagonalSimian(string[,] newArray, int length)
        {
            List<string> list = new List<string>();
            var array = ParseDiagonalArray(newArray, length);
            var array2 = ParseDiagonalReverseArray(newArray, length);
            list.AddRange(array); list.AddRange(array2);
            return list.ToArray();
        }

        public override bool[] CheckPattern(string[] dna)
        {
            string[,] newArray = new string[dna.Length, dna[0].Length];
            foreach (var item in dna.Select((value, index) => new { index, value }))
            {
                char[] row = item.value.ToCharArray();
                foreach (var chars in row.Select((value, index) => new { index, value }))
                {
                    newArray[item.index, chars.index] = chars.value.ToString();
                }
            }
            var newArraySimian = ParseDiagonalSimian(newArray, dna.Length);
            bool[] isSimian = new bool[newArraySimian.Length];
            foreach (var row in newArraySimian.Select((value, index) => new { index, value }))
                isSimian[row.index] = DefaultPattern.IsMatch(row.value);

            _logger.LogWarning("Resultado analise {0}: {1}", string.Join(",", newArraySimian), isSimian.Select(x => x));

            return isSimian;
        }

    }
}
