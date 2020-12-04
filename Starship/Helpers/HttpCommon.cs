using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Starship.Helpers
{
    public class HttpCommon : HttpClient
    {
        
        public  HttpCommon()
        {
            this.BaseAddress = new Uri("https://localhost:5001/");
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(
                  new MediaTypeWithQualityHeaderValue("application/json"));
           
        }
     }
}
