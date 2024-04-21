
using CodeChallenge.Features;
using Microsoft.Extensions.Configuration;

namespace CodeChallenge.API_Test
{
    public class APIInit
    {
        public string apiKey;
        public string apiOrdersAction;
        public string apiPatientsAction;
        public string apiEndPoint;

        public APIInit()
        {
            apiKey = "TBA";
            apiOrdersAction = "api/orders";
            apiPatientsAction = "api/patients";
            apiEndPoint = "https://localhost:44449/";

            IConfigurationSection appSettings = Utility.fGetConfigSection("appsettings", "appsettings.json");
            if (appSettings != null)
            {
                apiKey = appSettings["apiKey"];
                apiOrdersAction = appSettings["apiOrdersAction"];
                apiPatientsAction = appSettings["apiPatientsAction"];
                apiEndPoint = appSettings["apiEndPoint"];
            }
        }


  

    }
}
