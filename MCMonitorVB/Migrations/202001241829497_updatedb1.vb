Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class updatedb1
        Inherits DbMigration
    
        Public Overrides Sub Up()
            AlterColumn("dbo.Servers", "IsUp", Function(c) c.Boolean())
            AlterColumn("dbo.Servers", "NumConnections", Function(c) c.Int())
            AlterColumn("dbo.Servers", "LastChecked", Function(c) c.DateTime())
        End Sub
        
        Public Overrides Sub Down()
            AlterColumn("dbo.Servers", "LastChecked", Function(c) c.DateTime(nullable := False))
            AlterColumn("dbo.Servers", "NumConnections", Function(c) c.Int(nullable := False))
            AlterColumn("dbo.Servers", "IsUp", Function(c) c.Boolean(nullable := False))
        End Sub
    End Class
End Namespace
