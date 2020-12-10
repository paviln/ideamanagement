using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EskobInnovation.IdeaManagement.WPF.Helpers
{
  public class PrepHttpClient : HttpClient
  {
    private string apiKey = ConfigurationManager.AppSettings.Get("ApiKey");
    public PrepHttpClient()
    {
      this.BaseAddress = new Uri("https://localhost:5001/");
      this.DefaultRequestHeaders.Accept.Clear();
      this.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
      this.DefaultRequestHeaders.Add("ApiKey", apiKey);
    }
  }
}
