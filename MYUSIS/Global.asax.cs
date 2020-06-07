using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MYUSIS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            HttpContext.Current.Application["LifeTimeTotalVisitor"] = 0;
        }
        protected void Session_Start()
        {
            Session["OgrenciPageVisited"] = false;
            Session["OgretmenPageVisited"] = false;
            Session["AdminPageVisited"] = false;
            Session["OgrenciPageVisitedCounter"] = 0;
            Session["OgretmenPageVisitedCounter"] = 0;
            Session["AdminPageVisitedCounter"] = 0;

            Application["LifeTimeTotalVisitor"] = (int)Application["LifeTimeTotalVisitor"] + 1;
        }
    }
}
