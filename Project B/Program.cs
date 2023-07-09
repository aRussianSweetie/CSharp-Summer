using System;
using System.Linq;

namespace ProjectB
{
    class Program
    {
        static void Main()
        {
            var sequence = new[] { 1, 2, 3 };
            var k = 2;

            Console.WriteLine("Combinations with repetition:");
            foreach (var combination in sequence.CombinationsWithRepetition(k))
                Console.WriteLine(string.Join(", ", combination));

            Console.WriteLine("\nSubsets:");
            foreach (var subset in sequence.Subsets())
                Console.WriteLine(string.Join(", ", subset));

            Console.WriteLine("\nPermutations:");
            foreach (var permutation in sequence.Permutations())
                Console.WriteLine(string.Join(", ", permutation));
        }
    }
}
