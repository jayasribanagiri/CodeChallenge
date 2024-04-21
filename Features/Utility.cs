using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;


namespace CodeChallenge.Features
{
    public class Utility
    {
        private static CommonVars commonInstance = CommonVars.instance;

        
        public static bool launchEverLight()
        {
            //var tmp = SeleniumBrowserExtension.BrowserLaunch("Chrome", "https://localhost:44449/");
            var tmp = BrowserExtension.BrowserLaunch(commonInstance.BrowserType, commonInstance.EverLightUrl);
            return true;
        }//launchEverLight

        
        public static void LogExecutionMessage(string logType, string exeMessage)
        {
            switch (logType.ToLower())
            {
                default: //case "EqualTo":
                    Console.WriteLine(exeMessage);
                    break;
            }
        }
        public static JObject LoadJsonFile(string qualFilePath)
        {
            JObject jsonObject;
            try
            {
                jsonObject = JObject.Parse(File.ReadAllText(qualFilePath));
            }
            catch (Exception exCpn)
            {
                LogExecutionMessage("default", "Couldn't parse the file as Json - Error Message - " + exCpn.Message);
                return null;
            }

            return jsonObject;
        }// LoadJsonFile

       
        public static IConfigurationSection fGetConfigSection(string sectionName, string fileName, string filePath = "default")
        {
            filePath = Path.Combine(Directory.GetCurrentDirectory());

            var builder = new ConfigurationBuilder()
            .SetBasePath(filePath)
            .AddJsonFile(fileName, optional: false, reloadOnChange: true);
            //.AddEnvironmentVariables();

            IConfiguration appConfig = builder.Build();
            var section = appConfig.GetSection(sectionName);

            return section;
        }//fGetConfigSection



    }
}
