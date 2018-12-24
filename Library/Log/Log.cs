namespace UploadFileTest.Library.Log
{
    public static class Log
    {
        public static void WriteToJenkins(string subject, string message)
        {
            NUnit.Framework.TestContext.WriteLine($"*** CUTOMIZE LOG *** {System.DateTime.Now.ToUniversalTime().ToString()} : {subject}");
            NUnit.Framework.TestContext.WriteLine($"Message : {message}");
            NUnit.Framework.TestContext.WriteLine("");
        }
    }
}
