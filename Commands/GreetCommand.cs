using System;
using ConsoleApplication;
using ConsoleStarter.Interface;
using Microsoft.Extensions.CommandLineUtils;
using NLog;

namespace ConsoleStarter.Commands
{

    internal class GreetCommand : ICommand
    {

        private static ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly string _name;
        private readonly App _app;
        private bool _interactive = false;

        public GreetCommand(string name, App app)
        {
            _name = name;
            _app = app;
        }

        public int Run()
        {
            if (_app.Options.Interactive)
            {
                PromptWriter.Subcommand = "greet";
                _interactive = true;
                RunInteractive();
            }

            Console.WriteLine("Hello " + (_name != null ? _name : "World"));
            Console.WriteLine("Debug mode: " + _app.Options.Debug);
            return 0;
        }

        private int RunInteractive()
        {
            while (_interactive)
            {
                PromptWriter.WritePrompt();
                string temp = Console.ReadLine();

                if (string.IsNullOrEmpty(temp))
                {
                    continue;
                }

                var args = temp.Split(' ');

                App app = new App(args);

                try
                {
                    app.Initialize();
                    return app.Run();
                }
                catch (CommandParsingException e)
                {
                    _logger.Info(e.Message);
                    return e.HResult;
                }
                catch (Exception e)
                {
                    _logger.Debug(e.Message);
                    return e.HResult;
                }
            }

            return 0;
        }

        public static void Configure(App app, CommandLineApplication command)
        {
            command.Description = "An example command from the neat .NET Core Starter";
            command.HelpOption("--help|-h|-?");
            var nameArgument = command.Argument("name", "Name I should say hello to");
            command.OnExecute(() =>
            {
                app.Command = new GreetCommand(nameArgument.Value, app);
                return 0;
            });
        }
    }
}
