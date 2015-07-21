using System;
using System.Diagnostics;
using CLAP;

namespace BlogTalkRadio.Tools.CFT
{
    class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            // log to console by default
            try
            {
                Trace.AutoFlush = true;
                var traceListener = new ConsoleTraceListener();
                traceListener.TraceOutputOptions = TraceOptions.None;
                Trace.Listeners.Add(traceListener);
                Parser.RunConsole<App>(args);
            }
            catch (Exception ex)
            {
                WriteException(ex);
            }
        }

        public static void WriteException(Exception ex)
        {
            while (ex != null)
            {
                Console.WriteLine(ex.GetType().FullName);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                ex = ex.InnerException;
            }
        }
    }
}
