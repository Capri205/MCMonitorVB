Imports System.Web.Optimization
Imports MCMonitorVB.Models

Public Class MvcApplication
	Inherits System.Web.HttpApplication

	Private joinhash As Object

	Sub Application_Start()
		joinhash = New Hashtable()

		System.Data.Entity.Database.SetInitializer(Of MCMonitorDbContext)(New MCMonitorVB.Models.SeedData())
		AreaRegistration.RegisterAllAreas()
		FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
		RouteConfig.RegisterRoutes(RouteTable.Routes)
		BundleConfig.RegisterBundles(BundleTable.Bundles)
	End Sub
End Class
