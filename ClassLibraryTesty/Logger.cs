using System;
using System.IO;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace MusicPlayerBackend
{

    /// <summary>
    /// Capsulates the LogLvl.
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// Debugging level.
        /// </summary>
        Debug = 0,

        /// <summary>
        /// Information level.
        /// </summary>
        Informative = 1,

        /// <summary>
        /// Warning level.
        /// </summary>
        Warning = 2,

        /// <summary>
        /// Error level.
        /// </summary>
        Error = 3,

        /// <summary>
        /// Success level.
        /// </summary>
        Success = 4,
    }

    /// <summary>
    /// Enables controlled logging. Using Trace/Debug with custom Listeners.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Represents the logfile as stream.
        /// </summary>
        public static Stream LogFile { get; } = File.Create(Globals.LogPath);

        /// <summary>
        /// Translates the <see cref="LogSeverity"/> into neat strings.
        /// </summary>
        public static Dictionary<LogSeverity, string> LogLevelStr { get; } = new Dictionary<LogSeverity,string>() 
        {
            { LogSeverity.Debug, @" [Debug] " },
            { LogSeverity.Informative, @" [Information] " },
            { LogSeverity.Warning, @" [Warning] " },
            { LogSeverity.Error, @" [Error] " },
            { LogSeverity.Success, @" [Success] " },
        };

        private static bool _isSetup = false;
        private static TextWriterTraceListener _writerTraceListener = new TextWriterTraceListener(LogFile);
        private static ConsoleTraceListener _consoleTraceListener = new ConsoleTraceListener();

        /// <summary>
        /// Logs away threaded.
        /// </summary>
        /// <param name="severity"></param>
        /// <param name="caller"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static void Log(LogSeverity severity, object caller, string msg)
        {
            //write into log file
            if(!_isSetup)
            {
                _writerTraceListener.TraceOutputOptions = TraceOptions.Timestamp | TraceOptions.ProcessId | TraceOptions.ThreadId;
                _consoleTraceListener.TraceOutputOptions = TraceOptions.Timestamp | TraceOptions.ProcessId | TraceOptions.ThreadId | TraceOptions.Callstack;

                Trace.AutoFlush = true;
                Trace.Listeners.Add(_writerTraceListener);
                Trace.Listeners.Add(_consoleTraceListener);

                Debug.AutoFlush = true;
            }

            //extract data
            var loglvl = LogLevelStr[severity];
            var callerName = caller.GetType().FullName;
            string msgstr = loglvl + callerName + ": " + msg;

            //tracelog
            if(severity == LogSeverity.Informative || severity == LogSeverity.Success)
                Trace.TraceInformation(msgstr);
            else if (severity == LogSeverity.Warning)
                Trace.TraceWarning(msgstr);
            else if (severity == LogSeverity.Error)
                Trace.TraceError(msgstr);

            //debuglog
            else if(severity == LogSeverity.Debug)
                Debug.Print(msgstr);

        }
    }
}