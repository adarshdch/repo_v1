﻿
using System.Web.Mvc;
using System.Web.Routing;

namespace SAB.Interface
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{pagecode}",
				defaults: new {controller = "Page", action = "v1", pagecode = UrlParameter.Optional}
			);
		}
	}
}