using System.Runtime.Versioning;

namespace Profit.Integrator.Logging
{
#nullable disable
    [UnsupportedOSPlatform("browser")]
    internal class BufferLogRecordProcessor
    {
        public BufferCollection<LogRecord> Queue => _logQueue;
        private BufferCollection<LogRecord> _logQueue;
        private Thread _outputThread;
        private Func<ThreadStart, BufferCollection<LogRecord>> _initialize;
        public BufferLogRecordProcessor(uint bufferSize = 2048)
        {
            _logQueue = new BufferCollection<LogRecord>((int)bufferSize);
            _initialize = Initialize;
        }

        BufferCollection<LogRecord> Initialize(ThreadStart handler)
        {
            _initialize = null;
            _outputThread ??= new Thread(handler)
            {
                IsBackground = true,
                Name = "Buffered log queue processing thread"
            };
            _outputThread.Start();
            return _logQueue;
        }

        public void SetProprity(ThreadPriority level)
        {
            if (_outputThread is Thread thread)
                thread.Priority = level;
        }

        public void Flush()
        {
            _logQueue.CompleteAdding();
        }

        public BufferCollection<LogRecord> RunProcessing(ThreadStart handler)
        {
            return _initialize?.Invoke(handler);
        }
    }
#nullable enable
}
