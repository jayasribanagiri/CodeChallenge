using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using CodeChallenge.Features;
using RestSharpApi;

namespace CodeChallenge.API_Test
{
    public  class APIUsage
    
        
        {
            public JsonApi apiJson;
            public APIInit apiVars;

            public APIUsage()
            {
                apiVars = new APIInit();
                apiJson = new JsonApi(apiVars.apiEndPoint);
            }//OrdersApiUsage

            // ===================================================================================================
            /// <summary>
            /// 
            /// </summary>
            /// <param name="accessionNumber"></param>
            /// <returns></returns>
            public JArray GetOrdersWithAccessionNumber(string accessionNumber)
            {
                var apiParams = new Dictionary<string, string>
            {                
                //{ "id", Id },
                { "accessionNumber", accessionNumber }
            };

                JArray jsonResult = apiJson.GetServiceResponse<JArray>("GET", apiVars.apiOrdersAction, apiParams);
                if ((jsonResult == null) || (apiJson.restStatusCode != HttpStatusCode.OK))
                {
                    Utility.LogExecutionMessage("default", "Deserialization failed - Error Message - " + apiJson.restStatusDescription);
                    return null;
                }
                return jsonResult;
            }// GetOrdersWithAccessionNumber


            
            /// <param name="jsonArray"></param>
            /// <returns></returns>
            public IList<APIOrders> DeserializeResultsJArray(JArray jsonArray)
            {
                List<APIOrders> lstOrders = new List<APIOrders>();
                foreach (var obj in jsonArray)
                {
                    try
                    {
                        var orderItem = JsonConvert.DeserializeObject<APIOrders>(obj.ToString());
                        if (orderItem != null)
                            lstOrders.Add(orderItem);
                    }
                    catch (Exception exCpn)
                    {
                        Utility.LogExecutionMessage("default", "Deserialization failed - Error Message - " + exCpn.Message);
                        return null;
                    }
                }// end for loop           


                return lstOrders;
            }
        }
    }

