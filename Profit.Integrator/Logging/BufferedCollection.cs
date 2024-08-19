using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
namespace Profit.Integrator.Logging
{
    internal class BufferCollection<TUnit> : BlockingCollection<TUnit>
    {
        public BufferCollection(int capacity = 2048) : base(capacity)
        {
        }

        public IEnumerable<TUnit[]> BufferButches(int batchSize)
            => GetConsumingEnumerable().Chunk(batchSize);
    }
}


