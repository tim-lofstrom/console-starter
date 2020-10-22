using System;
using ConsoleApplication;
using Microsoft.Extensions.CommandLineUtils;
using NLog;
using Logger = ConsoleApplication.Logger;

namespace ConsoleStarter
{
    public class Program
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public static int Main(string[] args)
        {
            App app = new App(args);

            try
            {
                app.Initialize();
                return app.Run();
            }
            catch (CommandParsingException e)
            {
                logger.Info(e.Message);
                return e.HResult;
            }
            catch (Exception e)
            {
                logger.Debug(e.Message);
                return e.HResult;
            }

        }
    }
}
