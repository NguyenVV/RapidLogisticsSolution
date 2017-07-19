using System;
using System.IO;

namespace Ultilities
{
    public class FileHelper
    {
        public static void WriteLog(ExceptionLevel level, string whereOccur, Exception ex)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogExceptionFile.txt", true);
                writer.WriteLine("Exception at : "+ whereOccur+ " on :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                writer.WriteLine("Exception message : " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                writer.WriteLine("Exception stacktrace : " + ex.Source.ToString().Trim() + "; " + ex.StackTrace.Trim());
                writer.WriteLine("============================================================================================");
                writer.Flush();
                writer.Close();
            }
            catch { }
        }

        public static void WriteLog(string message)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\LogExceptionFile.txt", true);
                writer.WriteLine();
                writer.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ": " + message);
                writer.Flush();
                writer.Close();
            }
            catch { }
        }
    }


}
