using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Numerics;

namespace C386_Partition_counts.Sequencers
{
    /**
     * To get the amount of possibilities one has to use the following equation:
     * p(n) = p(n-1) + p(n-2) - p(n-5) - p(n-7) + p(n-12) + p(n-15) - ...
     * n >= 0
     * p(0) = 1
     * 
     * When n < 0 then the sequence stops. The value p(n) where n < 0 will not get added/subtracted to the sequence. 
     */
    public class Partitioner
    {
        private static Dictionary<long, BigInteger> memo = new Dictionary<long, BigInteger>();
        public static BigInteger GetPossibilities(long value) 
        {
            Alternator alternator = new Alternator();
            BigInteger possibilities = 0;
            long oldValue = 1;

            if (value == 0)
                return 1;
            if (value < 0)
                return 0;

            long newValueOutside = value - oldValue;
            BigInteger tempPossibilitiesOutside;
            if (!memo.TryGetValue(newValueOutside, out tempPossibilitiesOutside))
            {
                tempPossibilitiesOutside = GetPossibilities(newValueOutside);
                memo.Add(newValueOutside, tempPossibilitiesOutside);
            }
            if (tempPossibilitiesOutside == 0)
                return possibilities;
            possibilities += tempPossibilitiesOutside;

            while (true)
            {
                oldValue = alternator.GetNext() + oldValue;
                long newValue = value - oldValue;
                BigInteger tempPossibilities;
                if (!memo.TryGetValue(newValue, out tempPossibilities))
                {
                    tempPossibilities = GetPossibilities(newValue);
                    memo.Add(newValue, tempPossibilities);
                }
                if (tempPossibilities == 0)
                    return possibilities;
                possibilities += tempPossibilities;
                
                for(int i = 0; i < 2; i++)
                {
                    oldValue = alternator.GetNext() + oldValue;
                    newValue = value - oldValue;
                    if (!memo.TryGetValue(newValue, out tempPossibilities))
                    {
                        tempPossibilities = GetPossibilities(newValue);
                        memo.Add(newValue, tempPossibilities);
                    }
                    if (tempPossibilities == 0)
                        return possibilities;
                    possibilities -= tempPossibilities;
                }

                oldValue = alternator.GetNext() + oldValue;
                newValue = value - oldValue;
                if (!memo.TryGetValue(newValue, out tempPossibilities))
                {
                    tempPossibilities = GetPossibilities(newValue);
                    memo.Add(newValue, tempPossibilities);
                }
                if (tempPossibilities == 0)
                    return possibilities;
                possibilities += tempPossibilities;
            }
        }

        public static void BuildDictionary(int value)
        {
            for (int i = 0; i < value; i++)
            {
                Debug.WriteLine("Calculating {0}", i);
                memo.Add(i, GetPossibilities(i));
            }
        }
    }
}
