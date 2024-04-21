using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Reflection;


namespace CodeChallenge.Features
{
    public class BrowserExtension
    {
        public static void BrowerWaitForReadyState(IWebDriver driver)
        {
            WebDriverWait driverWaitObj = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            driverWaitObj.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        
        public static IWebDriver? GetBrowserObject(string browserType)
        {
            IWebDriver webDriver = null;
            string webDriverfolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            switch (browserType.ToLower())
            {
                case "firefox":
                    
                    break;

                case "edge":
                    webDriver = new EdgeDriver(webDriverfolder);
                    break;

                //default  Chrome Browser
                default:
                    ChromeOptions crBrowserOptions = new ChromeOptions();
                    crBrowserOptions.AddArguments("--start-maximized");
                    webDriver = new ChromeDriver(webDriverfolder, crBrowserOptions);
                    break;
            }

            CommonVars.instance.webDriver = webDriver;
            return webDriver;

        } 
        public static IWebDriver BrowserLaunch(string browserType, string UrlString)
        {
            IWebDriver webDriver = GetBrowserObject(browserType);
            if (webDriver != null)
            {
                webDriver.Navigate().GoToUrl(UrlString);
            }

            return webDriver;
                //.CurrentWindowHandle == null ? null : webDriver;

        } //BrowserLaunch





    }
}

 
