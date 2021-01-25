using System;
using System.Collections.Generic;
using System.Text;

namespace C386_Partition_counts.Sequencers
{
    public class Alternator : ISequencer
    {
        /**
         * In Order to make the following sequenze:
         * 1, 3, 2, 5, 3, 7, 4, 9, 5, 11, 6, 13, 7, ...
         * 
         * You need to add and subtract the following values
         * +2 -1 +3 -2 +4 -3...
         */
        private readonly Counter normalToOddCounter; //+2, +3, +4,...
        private readonly Counter oddToNormalCounter; //-1, -2, -3,...
        private bool usedNormalToOddCounter;
        private long returnValue;

        public Alternator()
        {
            normalToOddCounter = new Counter(2, 1);
            oddToNormalCounter = new Counter(-1, -1);
            returnValue = 1;
            usedNormalToOddCounter = false;
        }

        public long GetNext()
        {
            long returnValueLoc = returnValue;
            if (usedNormalToOddCounter)
            {
                returnValue += oddToNormalCounter.GetNext();
                usedNormalToOddCounter = false;
            }
            else
            {
                returnValue += normalToOddCounter.GetNext();
                usedNormalToOddCounter = true;
            }
            return returnValueLoc;
        }

        public void Reset()
        {
            normalToOddCounter.Reset();
            oddToNormalCounter.Reset();
            returnValue = 1;
        }
    }
}
