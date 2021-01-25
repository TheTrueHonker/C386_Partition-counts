using System;
using System.Collections.Generic;
using System.Text;

namespace C386_Partition_counts.Sequencers
{
    public class Counter : ISequencer
    {
        protected long returnValue;
        protected long startingPoint;
        protected readonly int modifier;

        public Counter(long startingPoint, int modifier)
        {
            this.startingPoint = startingPoint;
            this.modifier = modifier;
            returnValue = startingPoint;
        }

        public long GetNext()
        {
            long returnValueLoc = returnValue;
            returnValue += modifier;
            return returnValueLoc;
        }

        public void Reset()
        {
            returnValue = startingPoint;
        }
    }
}
