using System.Net;
using System.Xml;
using CodeChallenge.RestAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace RestSharpApi
{
    public class JsonApi
    {       
        public RestClient restClient;
        public RestRequest restRequest;

        public HttpStatusCode restStatusCode;
        public string restStatusDescription;

        public string encoding;
        public string jsonVersion;
        
                       
        public string jsonEndPoint;
        public string jsonEndPointDnsSafeHost;

        public string jsonActionUri;
        public string jsonActionName;
        public string jsonQualActionUri;

        public int contentLength = 0;

        //=================================================================================
        //=================================================================================
        public JsonApi(string apiEndPoint)
        {
            jsonEndPoint = apiEndPoint;
            jsonEndPointDnsSafeHost = new Uri(jsonEndPoint).DnsSafeHost;
           
        }
    


        //=================================================================================
        /// <summary>
        /// //      
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiVerb"></param>
        /// <param name="qualAction"></param>
        /// <param name="dctParams"></param>
        /// <returns></returns>
        public T GetServiceResponse<T>(string apiVerb, string qualAction, Dictionary<string, string> dctParams)
        {
            CodeChallenge.RestAPI.IRestResponse restResponse = GetWebResponse(apiVerb, qualAction, dctParams);

            restStatusCode = restResponse.StatusCode;
            restStatusDescription = restResponse.StatusDescription;
            string apiResponse = (string)restResponse.Content; // raw content as string

            if (string.IsNullOrEmpty(apiResponse))
            {
                throw new Exception("API response content is null or empty.");
            }
            // Use RestSharp's built-in deserializer
            //var deserializer = new RestSharp.Deserializers.JsonDeserializer();
           // if(typeof(T) == typeof(Dictionary<string, string>))
   // {
              //  var rtnObject = deserializer.Deserialize<Dictionary<string, string>>(restResponse);
              //  return (T)Convert.ChangeType(rtnObject, typeof(T));
          //  }
            if (typeof(T) == typeof(Dictionary<string, string>))
            {
                // Use Newtonsoft.Json for deserialization instead of RestSharp's JsonDeserializer
                var rtnObject = JsonConvert.DeserializeObject<Dictionary<string, string>>(apiResponse);
                return (T)Convert.ChangeType(rtnObject, typeof(T));
            }
            else if (typeof(T) == typeof(XmlDocument))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(apiResponse);
                return (T)Convert.ChangeType(xmlDoc, typeof(T));
            }
            else if (typeof(T) == typeof(JObject))
            {
                JObject jobject = JObject.Parse(apiResponse);
                return (T)Convert.ChangeType(jobject, typeof(T));
            }
            else if (typeof(T) == typeof(JArray))
            {
                JArray jarray = JArray.Parse(apiResponse);
                return (T)Convert.ChangeType(jarray, typeof(T));
            }
            else
            {
                return (T)Convert.ChangeType(apiResponse, typeof(T));
            }
        }

        //=================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualAction"></param>
        /// <param name="apiVerb"></param>
        /// <param name="dctParams"></param>
        /// <returns></returns>
        private IRestResponse GetWebResponse(string apiVerb, string qualAction, Dictionary<string, string> dctParams)
        {
            // *****************************************************************************
            //      Set the class props derived from the qual action name provided 
            // *****************************************************************************            
            Uri baseUri = new Uri(jsonEndPoint);
            jsonQualActionUri = new Uri(baseUri, qualAction).ToString();

            jsonActionUri = new Uri(jsonQualActionUri).GetLeftPart(UriPartial.Authority);
            var arrTmp = new Uri(jsonQualActionUri).Segments.ToArray();
            jsonActionName = arrTmp.Last();
            // *****************************************************************************            

            CreateHttpWebRequest(apiVerb, dctParams);

            //  var response = restClient.Execute(restRequest);
            // IRestResponse response = restClient.Execute(restRequest);
            RestRequest restRequest = new RestRequest(apiVerb, Method.Post); // Example assuming POST method
            restRequest.AddHeader("Content-Type", "application/json"); // Example header

            foreach (var param in dctParams)
            {
                restRequest.AddParameter(param.Key, param.Value);
            }

            // Execute the request using the RestSharp RestClient
            IRestResponse response = (IRestResponse)restClient.Execute(restRequest);

            return response;
        

           
        }// GetWebResponse

        //=================================================================================        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiVerb"></param>
        private void CreateHttpWebRequest(string apiVerb, Dictionary<string, string> dctParams)
        {
            restClient = new RestClient(jsonQualActionUri);
            restRequest = new RestRequest();
            //restRequest.Parameters.Clear();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = GetRestMethodType(apiVerb);

            foreach (string paramKey in dctParams.Keys)
            {
                restRequest.AddParameter(paramKey, dctParams[paramKey]);
            }
        }// fCeateHttpWebRequest

        //=================================================================================
        ///
        private static Method GetRestMethodType(string apiVerb)
        {
            Method rtnValue = Method.Get;
            switch (apiVerb.ToLower())
            {
                case "get":
                    rtnValue = Method.Get;
                    break;
                case "put":
                    rtnValue = Method.Put;
                    break;
                case "post":
                    rtnValue = Method.Post;
                    break;
                case "delete":
                    rtnValue = Method.Delete;
                    break;
                case "options":
                    rtnValue = Method.Options;
                    break;

                case "copy":
                    rtnValue = Method.Copy;
                    break;
                case "head":
                    rtnValue = Method.Head;
                    break;
                case "merge":
                    rtnValue = Method.Merge;
                    break;
                case "patch":
                    rtnValue = Method.Patch;
                    break;
            }

            return rtnValue;
        }//GetRestMethodType

    }//class
}//namespace

