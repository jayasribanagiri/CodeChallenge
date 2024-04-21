using System.Net;

namespace CodeChallenge.RestAPI
{
    internal interface IRestResponse
    {
        HttpStatusCode StatusCode { get; set; }
        string StatusDescription { get; set; }
        object Content { get; set; }
        bool IsSuccessful { get; }
    }
}