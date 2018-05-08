using CeremonyBazar.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace CeremonyBazar.App_Start
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            
            config.DependencyResolver = new DependencyResolver(UnityBootStrapper.RegisterTypes());
        }
    }
}