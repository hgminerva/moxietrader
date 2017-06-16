using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace moxietrader
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{symbol}",
                defaults: new { Key = RouteParameter.Optional, symbol = RouteParameter.Optional, Action = "Get" }
            );
        }
    }
}
