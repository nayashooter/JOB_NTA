using UploadFileTest.Library.Driver;
using UploadFileTest.Library.Proxy;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Text;
using System.Net;
using System.IO;

namespace UploadFileTest
{
    [TestFixture]
    /*[TestLinkFixture(
        Url = "http://localhost/testlink/lib/api/xmlrpc/v1/xmlrpc.php",
        ProjectName = "BSI",
        UserId = "admin",
        TestPlan = "Authentification",
        TestSuite = "Identification avec identifiant ok/",
        DevKey = "e161f73815492f9ba9f7ada9a6a1b23d")]*/
    public class TestClass
    {
        private DriverInternetExplorerUtils _driverIe;
        private ProxyUtils _proxy;
        private string devKey;
        private string testcaseexternalid;
        private string testplanid;

        [SetUp]
        public void Initialize()
        {
            devKey = TestContext.Parameters.Get("devKey"); //, "e161f73815492f9ba9f7ada9a6a1b23d"
            testcaseexternalid = TestContext.Parameters.Get("testcaseexternalid"); //, "BSI-3"
            testplanid = TestContext.Parameters.Get("testplanid"); //, "14"

            TestContext.WriteLine($"devKey : {devKey}");
            TestContext.WriteLine($"testcaseexternalid : {testcaseexternalid}");
            TestContext.WriteLine($"testplanid :{testplanid}");

            _proxy = new ProxyUtils("inetproxy:83");
            _driverIe = new DriverInternetExplorerUtils(_proxy);
            _driverIe.GetDriverInternet().Manage().Window.Maximize();
        }


        //[Test]
        //public void TestUploadFile()
        //{
        //    _driverIe.Wait(10);

        //    // se rend à la page www.google.fr
        //    _driverIe.GetDriverInternet().Navigate().GoToUrl("http://nervgh.github.io/pages/angular-file-upload/examples/simple/");
        //    _driverIe.Wait(10);

        //    //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Click();
        //    //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Clear();
        //    //string File = @"D:\S2H - POLE TEST ET CONFORMITE\Workspace\NUnit\UploadFileTest\Data\Files\callapp.png";
        //    string File = @"C:\image.png";
        //    _driverIe.Wait(500);

        //    var inputFile = _driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]"));
        //    _driverIe.Wait(500);
        //    inputFile.SendKeys(File);
        //    _driverIe.Wait(50);
        //    _driverIe.GetDriverInternet().FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

        //    Assert.IsTrue(true);
        //}

        [Test]
        public void TestSearchGoogle()
        {
            _driverIe.Wait(10);
            // se rend à la page www.google.fr
            _driverIe.GetDriverInternet().Navigate().GoToUrl("http://www.google.fr");
            _driverIe.Wait(120);
            _driverIe.GetDriverInternet().FindElement(By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input")).SendKeys("news");
            _driverIe.Wait(10);
            // lance la recherche
            _driverIe.GetDriverInternet().FindElement(By.Name("q")).Submit();
            Assert.IsTrue(true);

            //var xml = @"<?xml version=""1.0""?><methodCall><methodName>tl.updateTestCase</methodName><params><param><value><struct><member><name>devKey</name><value><string>e161f73815492f9ba9f7ada9a6a1b23d</string></value></member><member><name>testcaseexternalid</name><value><string>BSI-1</string></value></member><member><name>status</name><value><string>4</string></value></member></struct></value></param></params></methodCall>";
            var xml = @"<?xml version=""1.0""?><methodCall><methodName>tl.reportTCResult</methodName><params><param><value><struct><member><name>devKey</name><value><string>" + devKey + "</string></value></member><member><name>testcaseexternalid</name><value><string>" + testcaseexternalid + "</string></value></member><member><name>testplanid</name><value><int>" + testplanid + "</int></value></member><member><name>status</name><value><string>p</string></value></member><member><name>buildid</name><value><int>1</int></value></member></struct></value></param></params></methodCall>";

            byte[] requestData = Encoding.ASCII.GetBytes(xml);

            // Define the request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/testlink/lib/api/xmlrpc/v1/xmlrpc.php");
            request.Method = "POST";
            request.ContentType = "text/xml";
            request.ContentLength = requestData.Length;
            request.ServerCertificateValidationCallback = delegate { return true; }; //only needed to allow self-signed certificates. If possible don't use this

            using (Stream requestStream = request.GetRequestStream())
                requestStream.Write(requestData, 0, requestData.Length);

            string result = null;

            // Send XML to the API
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.ASCII))
                    {
                        result = reader.ReadToEnd();
                        TestContext.WriteLine($"Push Execution result : {result}");
                    }

                }

            }
        }

        [TearDown]
        public void EndTest()
        {
            if (_driverIe.GetDriverInternet() != null)
            {
                _driverIe.GetDriverInternet().Close();
            }
        }
    }
}
