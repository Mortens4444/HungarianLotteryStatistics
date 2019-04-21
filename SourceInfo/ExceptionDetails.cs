using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Enums;

#if !__MonoCS__
// Add System.Management.dll to references in Windows
using System.Management;
#endif

namespace SourceInfo
{
    public class ExceptionDetails
    {
        public Exception Exception { get; private set; }

        public string ExceptionType { get; private set; }

        public string[] StackFrameDetials { get; private set; }

        private readonly Exception firstException;

        public ExceptionDetails(Exception ex)
        {
            firstException = ex;
            var stackFrameDetails = new List<string> { StackDetails(ex) };

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                var stackDetail = StackDetails(ex);
                if (!String.IsNullOrEmpty(stackDetail))
                {
                    stackFrameDetails.Add(stackDetail);
                }
            }
            StackFrameDetials = stackFrameDetails.ToArray();
            Exception = ex;
            ExceptionType = ex.GetType().ToString();
        }

        private static string StackDetails(Exception ex)
        {
            var result = new StringBuilder();
            var stack = new StackTrace(ex, true);

            var frames = stack.GetFrames();
            foreach (var stackFrame in frames)
            {
                // File and line information
                if (stackFrame.GetFileName() != null)
                {
                    result.AppendFormat("<{0}, Line: {1}>", stackFrame.GetFileName(), stackFrame.GetFileLineNumber());
                    result.AppendLine();
                }

                // Method and parameter information
                var method = stackFrame.GetMethod();
                if (method != null)
                {
                    if (method.IsConstructor)
                        result.Append(method.ReflectedType.FullName);
                    else if ((method.Name == ".cctor") && (method.IsStatic) && (method.IsSpecialName))
                        result.Append(String.Concat("static ", method.ReflectedType.FullName));
                    else
                        result.Append(method.Name);
                    var parameters = String.Join(", ", method.GetParameters().Select(parameter => parameter.ToString()));
                    result.AppendFormat("({0})", parameters);
                }
                result.AppendLine();
            }
            return result.ToString();
        }

        private Exception GetParentException(Exception ex)
        {
            if (ex == firstException)
            {
                return null;
            }
            var result = firstException;
            while (result.InnerException != ex)
            {
                result = result.InnerException;
            }
            return result;
        }

        public string Messages
        {
            get
            {
                return GetDetailsToRoot(Exception);
            }
        }

        public string Details
        {
            get
            {
                return GetDetailsToRoot(Exception, true);
            }
        }

        private string GetDetailsToRoot(Exception ex, bool extraInfo = false)
        {
            var details = new StringBuilder();

            if (extraInfo)
            {
                details.AppendLine(String.Join(Environment.NewLine, StackFrameDetials));
            }

            do
            {
                if (extraInfo)
                {
                    details.AppendFormat("{0} - ", ex.GetType());
                }
                AppendDetails(details, ex);
                ex = GetParentException(ex);
            }
            while (ex != null);

            return details.ToString();
        }

        private static void AppendDetails(StringBuilder stringBuilder, Exception ex)
        {
            stringBuilder.AppendLine(ex.Message);

            var win32Exception = ex as Win32Exception;
            if (win32Exception != null)
            {
                stringBuilder.AppendLine(String.Format("Win32 NativeErrorCode: {0} - {1}", win32Exception.NativeErrorCode, (SystemErrorCodes)win32Exception.NativeErrorCode));
            }
            #if !__MonoCS__
            else if (ex is ManagementException)
            {
                if (((ManagementException)ex).ErrorInformation != null)
                {
                    stringBuilder.Append("ErrorInformation description: ");
                    stringBuilder.AppendLine(Convert.ToString(((ManagementException)ex).ErrorInformation["Description"]));
                }
            }
            #endif
        }
    }
}
