using OpenQA.Selenium;

namespace CodeChallenge.Features
{
   public class CommonVars
    {
      
        private static readonly object _criticalArea = new object();

        [ThreadStatic]
        private static CommonVars _instance;
        public static CommonVars instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_criticalArea)
                    {
                        if (_instance == null)
                        {
                            _instance = new CommonVars();
                        }
                    }
                }
                return _instance;
            }
        }

        private CommonVars()
        {
            Microsoft.Extensions.Configuration.IConfigurationSection appSettings = Utility.fGetConfigSection("appsettings", "appsettings.json");
            AppName = appSettings["appName"];
            BrowserType = appSettings["browserType"];
            EverLightUrl = appSettings["everLightUrl"];

        }

        public string AppName { get; set; }
        public string UnqTestNumber { get; set; }
        public string BrowserType { get; set; }
        public string EverLightUrl { get; set; }
        public IWebDriver webDriver { get; set; }


 
    }
}
