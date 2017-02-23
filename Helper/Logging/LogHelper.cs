using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Diagnostics;

namespace Helper.Logging
{
    public static class LogHelper
    {
        private const string Layout = @"[${date:format=dd/MM/yyyy HH\:mm\:ss}] ${message}";
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static LogHelper()
        {
            LogManager.Configuration = new LoggingConfiguration();
            ConfigureTarget(new ColoredConsoleTarget { Name = "Console", Layout = Layout });
            ConfigureTarget(new FileTarget { Name = "File", Layout = Layout, FileName = "${basedir}/Logs/Log.txt" });
        }

        public static void Error(Exception exception)
        {
            var trace = new StackTrace(exception, true).GetFrame(0);
            Logger.Error($"[Message]: {exception.Message} [Trace]: File '{trace.GetFileName()}' Line '{trace.GetFileLineNumber()}'");
        }

        public static void Info(string message)
        {
            Logger.Info(message);
        }

        private static void ConfigureTarget(Target target)
        {
            var rule = new LoggingRule("*", LogLevel.Debug, target);
            LogManager.Configuration.AddTarget(target);
            LogManager.Configuration.LoggingRules.Add(rule);
        }
    }
}