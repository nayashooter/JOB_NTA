using OpenQA.Selenium;
using OpenQA.Selenium.IE;

namespace UploadFileTest.Library.Proxy
{
    public class ProxyUtils
    {
        private readonly OpenQA.Selenium.Proxy _proxyInstance;

        public ProxyUtils(string urlProxy)
        {
            _proxyInstance = new OpenQA.Selenium.Proxy { HttpProxy = urlProxy, SslProxy = urlProxy, Kind = ProxyKind.Manual, IsAutoDetect = false };
        }

        public InternetExplorerOptions GetIeOptions()
        {
            var options = new InternetExplorerOptions
            {
                //Proxy = _proxyInstance,
                EnsureCleanSession = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true
            };

            return options;
        }
    }
}
