using MessageBoxes;
using SourceInfo;
using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Lottó
{
    public static class UnhandledExceptionHandler
    {
        private static string unhandledExceptionsLogFile;
            
        public static void CatchUnhandledExceptions()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //Application.ThreadException += new ThreadExceptionEventHandler(Utils.ThreadExceptionHandler);

            var unhandledExceptionsFolder = String.Format("{0}/{1}/", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), System.Windows.Forms.Application.ProductName);
            unhandledExceptionsLogFile = String.Concat(unhandledExceptionsFolder, "unhandled_exception.txt");
            if (!Directory.Exists(unhandledExceptionsFolder))
            {
                Directory.CreateDirectory(unhandledExceptionsFolder);
            }
            
            var currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += UnhandledExceptionEventHandler;
        }

        private static void UnhandledExceptionEventHandler(Object sender, UnhandledExceptionEventArgs e)
        {
            HandledException(e.ExceptionObject as Exception);
        }

        private static void HandledException(Exception ex)
        {
            var errorDetails = new StringBuilder();
            var now = DateTime.Now;
            errorDetails.AppendFormat("{0} {1}{2}", now.ToShortDateString(), now.ToLongTimeString(), Environment.NewLine);
            errorDetails.Append(new ExceptionDetails(ex).Details);

            AppendLineToFile(unhandledExceptionsLogFile, errorDetails.ToString());
            try
            {
                ErrorBox.Show(ex, Timeout.Infinite);
            }
            catch { }
            Environment.Exit(-1);
        }

        private static void AppendLineToFile(string filePath, string lineToAppend)
        {
            using (var sw = File.AppendText(filePath))
            {
                if (String.IsNullOrEmpty(lineToAppend))
                {
                    sw.WriteLine();
                }
                else
                {
                    sw.WriteLine(lineToAppend);
                }
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
        }
    }
}
