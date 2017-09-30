﻿using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace Example.Api
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}