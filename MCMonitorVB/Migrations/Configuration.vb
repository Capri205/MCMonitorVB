Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Migrations
Imports System.Linq

Namespace Migrations

    Friend NotInheritable Class Configuration
        Inherits DbMigrationsConfiguration(Of Models.MCMonitorDbContext)

        Public Sub New()
            AutomaticMigrationsEnabled = False
            ContextKey = "MCMonitorVB.Models.MCMonitorDbContext"
        End Sub

        Protected Overrides Sub Seed(context As Models.MCMonitorDbContext)
            '  This method will be called after migrating to the latest version.

            '  You can use the DbSet(Of T).AddOrUpdate() helper extension method
            '  to avoid creating duplicate seed data.
        End Sub

    End Class

End Namespace
