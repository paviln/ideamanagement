using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EskobInnovation.IdeaManagement.API.Attributes
{
  [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
  public class ApiKeyAttribute : Attribute, IAsyncActionFilter
  {
    private const string APIKEY = "ApiKey";
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
      if (!context.HttpContext.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
      {
        context.Result = new ContentResult()
        {
          StatusCode = 401,
        };
        return;
      }

      var appSettings = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();

      var apiKey = appSettings.GetValue<string>(APIKEY);

      if (!apiKey.Equals(extractedApiKey))
      {
        context.Result = new ContentResult()
        {
          StatusCode = 401,
        };
        return;
      }
      await next();
    }
  }
}