using System;
using System.Collections.Generic;
using System.Text;

namespace C386_Partition_counts.Sequencers
{
    interface ISequencer
    {
        public long GetNext();
        public void Reset();

    }
}
