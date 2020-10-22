using ConsoleStarter;
using ConsoleStarter.Interface;
using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Commands
{
    internal class HelpCommand : ICommand
    {
        private readonly App _app;

        public HelpCommand(App app)
        {
            _app = app;
        }
        public int Run()
        {
            _app.CommandLineApplication.ShowHelp();
            return 0;
        }

        public static void Configure(App app, CommandLineApplication command)
        {
            command.Description = "Print help.";
            command.OnExecute(() =>
            {
                app.Command = new HelpCommand(app);
                return 0;
            });
        }
    }
}
