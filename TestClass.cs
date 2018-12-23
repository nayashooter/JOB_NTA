using UploadFileTest.Library.Driver;
using UploadFileTest.Library.Proxy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Meyn.TestLink;

namespace UploadFileTest
{
    [TestFixture]
    [TestLinkFixture(
        Url = "http://localhost/testlink/lib/api/xmlrpc/v1/xmlrpc.php",
        ProjectName = "BSI",
        UserId = "admin",
        TestPlan = "Authentification",
        TestSuite = "Identification avec identifiant ok/",
        DevKey = "e161f73815492f9ba9f7ada9a6a1b23d")]
    public class TestClass
    {
        private DriverInternetExplorerUtils _driverIe;
        private ProxyUtils _proxy;

        [SetUp]
        public void Initialize()
        {
            _proxy = new ProxyUtils("inetproxy:83");
            _driverIe = new DriverInternetExplorerUtils(_proxy);
            _driverIe.GetDriverInternet().Manage().Window.Maximize();
        }


        [Test]
        public void TestUploadFile()
        {
            _driverIe.Wait(10);

            // se rend à la page www.google.fr
            _driverIe.GetDriverInternet().Navigate().GoToUrl("http://nervgh.github.io/pages/angular-file-upload/examples/simple/");
            _driverIe.Wait(10);

            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Click();
            //_driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]")).Clear();
            //string File = @"D:\S2H - POLE TEST ET CONFORMITE\Workspace\NUnit\UploadFileTest\Data\Files\callapp.png";
            string File = @"C:\image.png";
            _driverIe.Wait(500);

            var inputFile = _driverIe.GetDriverInternet().FindElement(By.XPath("(//input[@type='file'])[2]"));
            _driverIe.Wait(500);
            inputFile.SendKeys(File);
            _driverIe.Wait(50);
            _driverIe.GetDriverInternet().FindElement(By.XPath("(//button[@type='button'])[4]")).Click();

            Assert.IsTrue(true);
        }

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
