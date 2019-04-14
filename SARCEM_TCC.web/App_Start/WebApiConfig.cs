using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace SARCEM_TCC.web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;


            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
               name: "way1",
               routeTemplate: "api/{controller}/{action}/{param1}",
                defaults: new
                {
                    param1 = RouteParameter.Optional,

                }

               );



            config.Routes.MapHttpRoute(
                name: "way2",
                routeTemplate: "api/{controller}/{action}/{param1}/{param2}",
                 defaults: new
                 {
                     param1 = RouteParameter.Optional,
                     param2 = RouteParameter.Optional

                 }

                );


            config.Routes.MapHttpRoute(
                name: "way3",
                routeTemplate: "api/{controller}/{action}/{param1}/{param2}/{param3}",
                 defaults: new
                 {
                     param1 = RouteParameter.Optional,
                     param2 = RouteParameter.Optional,
                     param3 = RouteParameter.Optional

                 }

                );




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
