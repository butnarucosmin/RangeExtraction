using System;
using System.Linq;
using System.Text;

namespace RangeExtraction
{
    public class RangeExtraction
    {
        public static string Extract(int[] args)
        {
            return CompactNumberRanges(args, 3);
        }

        public static string CompactNumberRanges(int [] numbers,
                                   int requiredRangeCount)
        {
            if (requiredRangeCount <= 1)
                throw new ArgumentOutOfRangeException("requiredRangeCount");

            int[] sorted = numbers.OrderBy(e => e).ToArray();

            StringBuilder b = new StringBuilder();

            for (int i = 0; i < sorted.Length; i++)
            {
                int cv = sorted[i];
                int count = 0;

                for (int j = cv; ; j++)
                {
                    if (Array.IndexOf(sorted, j) == -1)
                        break;
                    else
                        count++;
                }

                if (count == 0)
                    throw new InvalidOperationException();
                else if (count < requiredRangeCount)
                    b.Append(",").Append(cv);
                else if (count >= requiredRangeCount)
                {
                    b.Append(",").AppendFormat("{0}-{1}", cv, sorted[i + count - 1]);

                    i += count - 1;
                }
            }

            return b.ToString().Trim(',');
        }
    }
}
