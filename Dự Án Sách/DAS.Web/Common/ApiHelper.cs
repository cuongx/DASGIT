using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAS.Web.Common
{
    public class ApiHelper<T>where T : class
    {
        public static T HttpGetAsync(string apiUrl, string method = "GET")
        {
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(apiUrl);
            httpRequest.Method = method;
            string responsedata;
            var response = httpRequest.GetResponse();
            {

                Stream stream = response.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
               responsedata= streamReader.ReadToEnd();
            }
            return Json
        }
    }
}
