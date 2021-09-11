using Hangfire.Logging;

namespace SME.Worker.Agendador.Hangfire.Logging
{
    public class SentryLogProvider : ILogProvider
    {
        public ILog GetLogger(string name)
        {
            return new SentryLog();
        }
    }
}
