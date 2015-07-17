using System.Net.Http.Headers;
using System.Web.Http;

namespace Host
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{action}",
                defaults: new { controller = "DataApi", action = "Time" }
            );
        }
    }
}
