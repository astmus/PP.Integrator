using System.Collections.Concurrent;
namespace PP.Integrator.Logging
{
    internal class BufferCollection<TUnit> : BlockingCollection<TUnit>
    {
        public BufferCollection(int capacity = 2048) : base(capacity)
        {
        }

        public IEnumerable<TUnit[]> BufferButches(int batchSize)
            => this.GetConsumingEnumerable().Chunk(batchSize);
    }
}


