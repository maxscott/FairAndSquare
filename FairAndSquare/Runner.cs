using System;
using System.Collections.Generic;
using System.Linq;

namespace FairAndSquare
{
    class Runner
    {
        static void Main(string[] args)
        {
            var numCases = int.Parse(Console.ReadLine() ?? "0");

            var cases = new List<Case>();

            for (int i = 0; i < numCases; i++)
            {
                var nm = (Console.ReadLine() ?? "-1 -1").Split(' ').Select(ulong.Parse).ToArray();

                cases.Add(new Case(nm[0], nm[1], i+1));
            }

            cases.AsParallel().ForAll(c => c.Run());

            foreach (var c in cases.OrderBy(c => c.CaseNum))
            {
                Console.WriteLine(CasePart(c.CaseNum) + c.Result);
            }
        }

        public static string CasePart(int caseNumber)
        {
            return "Case #" + caseNumber + ": ";
        } 
    }
}