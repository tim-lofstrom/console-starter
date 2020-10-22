using System;
using ConsoleApplication;
using ConsoleStarter.Interface;
using Microsoft.Extensions.CommandLineUtils;

namespace ConsoleStarter
{
    internal class App
    {
        public ICommand Command { get; set; }
        public CommandLineApplication CommandLineApplication { get; set; }
        public GlobalOptions Options { get; private set; }
        public GlobalSettings Settings { get; private set; }
        public string[] Args { get; private set; }

        public App(string[] args)
        {
            CommandLineApplication = new CommandLineApplication
            {
                Name = "console-starter",
                FullName = ".NET Core Neat Console Starter"
            };
            Args = args;
        }

        internal void Initialize()
        {
            Options = Parser.ParseGlobalOptions(this, Args);
            Settings = Parser.ParseGlobalSettings();

            if (!Options.Interactive)
            {
                CommandLineApplication.HelpOption("-?|-h|--help");
            }

            Logger.ConfigureLogger(Options.Debug);
        }

        internal int Run()
        {
            return Command.Run();
        }
    }
}