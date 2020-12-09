using System;
using System.Net.Http;
using System.Net.Http.Headers;


namespace EskobInnovation.IdeaManagement.WPF.Helpers
{
    public class ApiHelper : HttpClient
    {
        public  ApiHelper()
        {
            this.BaseAddress = new Uri("https://localhost:5001/");
            this.DefaultRequestHeaders.Accept.Clear();
            this.DefaultRequestHeaders.Accept.Add(
                  new MediaTypeWithQualityHeaderValue("application/json"));     
        }
    }
}
