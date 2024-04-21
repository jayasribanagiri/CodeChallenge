using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;


namespace CodeChallenge.API_Test
{
    internal class APIOrdersTest
    {
        [TestClass]
        public class ApiOrdersTests
        {
            [TestMethod]
            public void TestAccessionNumber_00486()
            {
                // Call the api to get the results in Json
                APIUsage ordersApiUsage = new APIUsage();
                JArray jsonResult = ordersApiUsage.GetOrdersWithAccessionNumber("00486");
                if (jsonResult == null)
                {
                    Assert.Fail("Exiting - Couldn't retrieve results from Everlight Orders Api");
                }

                // Deserialize Results
                var Orders = ordersApiUsage.DeserializeResultsJArray(jsonResult);


            }// TestAccessionNumber_00486

        }
    }

}

