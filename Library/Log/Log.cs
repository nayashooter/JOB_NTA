namespace UploadFileTest.Library.Log
{
    public class Log
    {
        public Log()
        {
            NUnit.Framework.TestContext.WriteLine("*** CUTOMIZE LOG ***");
        }

        public void WriteToJenkins(string subject, string message)
        {
            NUnit.Framework.TestContext.WriteLine($"{System.DateTime.Now.ToUniversalTime().ToString()} : {subject}");
            NUnit.Framework.TestContext.WriteLine($"Message : {message}");
            NUnit.Framework.TestContext.WriteLine("");
        }
    }
}
