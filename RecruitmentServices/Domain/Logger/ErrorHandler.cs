using System;
using System.IO;

namespace Domain
{
    public static class ErrorHandler
    {
        public static void ErrorLogger(this Exception exception)
        {
            StreamWriter writer = new StreamWriter("");
            writer.WriteLine(exception.Message + DateTime.Today.ToString("dd/MM/yyyy"));
            writer.Close();
        }
        public static void ErrorStack (this Exception exception)
        {
            StreamWriter writer = new StreamWriter("");
            writer.WriteLine(exception.StackTrace + DateTime.Today.ToString("dd/MM/yyyy"));
            writer.Close();
        }
    }
}
