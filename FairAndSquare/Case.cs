using System;
using System.Globalization;
using System.Linq;

namespace FairAndSquare
{
    public class Case
    {
        private readonly ulong start;
        private readonly ulong end;

        public readonly int CaseNum;
        public ulong Result;

        public Case(ulong start, ulong end, int caseNum)
        {
            this.start = start;
            this.end = end;
            this.CaseNum = caseNum;
        }

        public void Run()
        {
            Result = 0;

            for (ulong i = start; i <= end; i++)
            {
                if (IsSquareAndRootFair(i) && IsFair(i))
                {
                    Result++;
                }
            }
        }

        static bool IsSquareAndRootFair(ulong i)
        {
            ulong sqrt = (ulong)Math.Sqrt(i);

            // not a square of another int
            if (sqrt * sqrt != i) return false;

            return IsFair(sqrt);
        }

        /// <summary> Is a palindrome... </summary>
        static bool IsFair(ulong num)
        {
            var str = num.ToString(CultureInfo.InvariantCulture);

            int start = 0;
            int end = str.Count() - 1;

            while (start < end)
            {
                if (str[start] != str[end])
                {
                    return false;
                }

                ++start;
                --end;
            }

            return true;
        }
    }
}
