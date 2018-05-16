using Sanlilar.BL;
using Sanlilar.WebUIAdmin.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Sanlilar.WebUIAdmin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Initialize();

            UserHelper.Id = 1;
            UserHelper.Adi = "admin";
            UserHelper.KullaniciAdi = "admin";
            UserHelper.Soyadi = "admin";

        }
    }
}
