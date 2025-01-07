namespace PP.Integrator.Logging
{
    /// <summary>
    /// 
    /// </summary>
	public interface ILogEntryWriter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="logEntry"></param>
        /// <param name="textWriter"></param>
        /// <param name="scope"></param>
        void Write<TState>(in LogEntry<TState> logEntry, TextWriter textWriter, object scope);
    }
}


