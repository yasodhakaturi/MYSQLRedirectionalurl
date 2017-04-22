using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Analytics.App_Start
{
    public class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    //var cors = new EnableCorsAttribute("https://g0.pe", "*", "*");
        //    //config.EnableCors(cors);
        //    //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        //    //config.EnableCors();

        //    config.MapHttpAttributeRoutes();
        //    //EnableCrossSiteRequests(config);
        //    //Addroutes(config);
        //}
        //private static void EnableCrossSiteRequests(HttpConfiguration config)
        //{
        //    var cors = new EnableCorsAttribute(
        //        origins: "*",
        //        headers: "*",
        //        methods: "*");
        //    config.EnableCors(cors);
        //}
    }
}