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
    internal class ExitCommand : ICommand
    {
        private App _app;

        public ExitCommand(App app)
        {
            _app = app;
        }

        public int Run()
        {
            _app.Options.Interactive = false;
            return 0;
        }

        public static void Configure(App app, CommandLineApplication command)
        {
            command.Description = "Terminate interactive session.";
            command.OnExecute(() =>
            {
                app.Command = new ExitCommand(app);
                return 0;
            });
        }
    }
}
