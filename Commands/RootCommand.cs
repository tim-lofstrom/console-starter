using ConsoleApplication;
using ConsoleApplication.Commands;
using ConsoleStarter.Interface;
using Microsoft.Extensions.CommandLineUtils;
using NLog;
using System;
using Logger = ConsoleApplication.Logger;

namespace ConsoleStarter.Commands
{

    internal class RootCommand : ICommand
    {
        private ILogger _logger = LogManager.GetCurrentClassLogger();
        private App _app;

        public RootCommand(App app)
        {
            _app = app;
        }

        public int Run()
        {
            if (_app.Options.Interactive)
            {
                ConfigureInteractive();
                return RunInteractive();
            }
            else
            {
                _app.CommandLineApplication.ShowHelp();
                return 1;
            }
        }

        private void ConfigureInteractive()
        {
            // Add help as commands
            _app.CommandLineApplication.Command("help", c => HelpCommand.Configure(_app, c));
            _app.CommandLineApplication.Command("?", c => HelpCommand.Configure(_app, c));

            // Can not specify root command options in interactive mode.
            _app.CommandLineApplication.Options.Clear();
        }

        private int RunInteractive()
        {
            while (_app.Options.Interactive)
            {
                PromptWriter.WritePrompt();
                string temp = Console.ReadLine();

                if (string.IsNullOrEmpty(temp))
                {
                    continue;
                }

                var args = temp.Split(' ');

                try
                {
                    // Configure up the new command
                    _app.CommandLineApplication.Execute(args);

                    // Run the command
                    _app.Command.Run();
                }
                catch (CommandParsingException e)
                {
                    _logger.Info(e.Message);
                }
            }

            return 0;
        }

        public static void Configure(App app)
        {
            app.CommandLineApplication.Command("greet", c => GreetCommand.Configure(app, c));
            app.CommandLineApplication.Command("exit", c => ExitCommand.Configure(app, c));
            app.CommandLineApplication.OnExecute(() =>
            {
                app.Command = new RootCommand(app);
                return 0;
            });
        }
    }
}
