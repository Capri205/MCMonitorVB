Imports System.Web.Optimization
Imports MCMonitorVB.Models

Public Class MvcApplication
	Inherits System.Web.HttpApplication

	Sub Application_Start()

		System.Data.Entity.Database.SetInitializer(Of MCMonitorDbContext)(New MCMonitorVB.Models.SeedData())
		AreaRegistration.RegisterAllAreas()
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
		RouteConfig.RegisterRoutes(RouteTable.Routes)
		BundleConfig.RegisterBundles(BundleTable.Bundles)
	End Sub
End Class
