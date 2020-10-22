using ConsoleStarter;
using ConsoleStarter.Commands;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Parser
    {
        public static GlobalOptions ParseGlobalOptions(App app, string[] args)
        {
            var options = new GlobalOptions();

            var debug = app.CommandLineApplication.Option("-d|--debug",
                "Show extra debug printouts.",
                CommandOptionType.NoValue);

            var interactiveSwitch = app.CommandLineApplication.Option("-i|--interactive",
                "Run application in interactive mode.",
                CommandOptionType.NoValue);

            RootCommand.Configure(app);

            var result = app.CommandLineApplication.Execute(args);

            if (result != 0)
            {
                return null;
            }

            options.Debug = debug.HasValue();
            options.Interactive = interactiveSwitch.HasValue();

            return options;
        }

        public static GlobalSettings ParseGlobalSettings()
        {
            return new GlobalSettings();
        }
    }
}
