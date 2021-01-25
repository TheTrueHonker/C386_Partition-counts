using System;
using System.Numerics;
using C386_Partition_counts.Sequencers;

namespace C386_Partition_counts
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---- Challenge #386 [Intermediate] Partition counts ----");
            Console.WriteLine();
            Console.WriteLine("Building Dictionary to 666.666");
            Partitioner.BuildDictionary(666666);
            Console.WriteLine();
            Console.WriteLine("Testing with p(66)");
            Console.WriteLine("Calculating...");
            BigInteger p66 = Partitioner.GetPossibilities(66);
            Console.WriteLine("Calculation complete. Function returned {0}", p66);
            if(p66 != 2323520)
            {
                Console.WriteLine("[ERROR] Function returned {0}. Expected 2323520", p66);
                Console.WriteLine("Closing Program now!");
                Console.ReadKey();
            }

            Console.WriteLine();
            Console.WriteLine("Testing with p(666)");
            Console.WriteLine("Calculating...");
            BigInteger p666 = Partitioner.GetPossibilities(666);
            Console.WriteLine("Calculatin complete. Function returned {0}", p666);

            Console.WriteLine();
            Console.WriteLine("Testing with p(666666)");
            Console.WriteLine("Calculating...");
            BigInteger p666666 = Partitioner.GetPossibilities(666666);
            Console.WriteLine("Calculatin complete. Function returned {0}", p666666);
        }
    }
}
