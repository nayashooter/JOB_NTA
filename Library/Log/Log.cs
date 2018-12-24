namespace UploadFileTest.Library.Log
{
    public static class Log
    {
        public static void WriteToJenkins(string subject, string message)
        {
            NUnit.Framework.TestContext.WriteLine("*** LOG BEGIN ***");
            NUnit.Framework.TestContext.WriteLine($"{System.DateTime.Now.ToLongDateString().ToString()} : {subject}");
            NUnit.Framework.TestContext.WriteLine("");
            NUnit.Framework.TestContext.WriteLine($"Message : {message}");
            NUnit.Framework.TestContext.WriteLine("");
            NUnit.Framework.TestContext.WriteLine("*** LOG END ***");
        }
    }
}
