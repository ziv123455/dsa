using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DSA___A2___Part_Soution
{
    class Program
    {
        static void Main()
        {
            SplitMix64 prng = new SplitMix64();

            // Part A: Correctness Demonstration
            Console.WriteLine("----- Part A: Correctness Demonstration -----");
            List<ulong> numbers = new List<ulong>();

            for (int i = 0; i < 100; i++)
            {
                numbers.Add(prng.Next(1, 1000));
            }

            bool allInRange = numbers.All(n => n >= 1 && n <= 1000);
            Console.WriteLine($"All numbers in range 1 to 1000: {allInRange}");

            bool sortedAscending = numbers.SequenceEqual(numbers.OrderBy(n => n));
            Console.WriteLine($"Numbers sorted ascending: {sortedAscending}");

            bool sortedDescending = numbers.SequenceEqual(numbers.OrderByDescending(n => n));
            Console.WriteLine($"Numbers sorted descending: {sortedDescending}");

            Console.WriteLine("Generated numbers:");
            Console.WriteLine(string.Join(", ", numbers));

            // Part B: Empirical Timing Analysis
            Console.WriteLine("\n----- Part B: Empirical Timing Analysis -----");
            int[] counts = { 1000, 10000, 100000, 1000000 };
            List<double> timings = new List<double>();

            foreach (var count in counts)
            {
                var stopwatch = Stopwatch.StartNew();

                for (int i = 0; i < count; i++)
                {
                    prng.Next(1, 1000);
                }

                stopwatch.Stop();
                double elapsedMs = stopwatch.Elapsed.TotalMilliseconds;
                timings.Add(elapsedMs);
                Console.WriteLine($"Count: {count} - Time taken: {elapsedMs} ms");
            }

            // Print CSV for Excel
            Console.WriteLine("\nCount,Time(ms)");
            for (int i = 0; i < counts.Length; i++)
            {
                Console.WriteLine($"{counts[i]},{timings[i]}");
            }
        }
    }
}
