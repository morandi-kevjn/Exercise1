using Newtonsoft.Json.Serialization; // ep69
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Exercise1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // ep 69 <<<
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Newtonsoft.Json.Formatting.Indented;
            
            // >>>

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
