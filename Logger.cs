using NLog;

namespace ConsoleApplication
{
    public static class Logger
    {
        public static void ConfigureLogger(bool verbose = false)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logconsole = new NLog.Targets.ConsoleTarget("console");
            logconsole.Layout = "${message}";

            if (verbose)
            {
                config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
            }
            else
            {
                config.AddRule(LogLevel.Info, LogLevel.Info, logconsole);
            }
            LogManager.Configuration = config;
        }
    }
}
