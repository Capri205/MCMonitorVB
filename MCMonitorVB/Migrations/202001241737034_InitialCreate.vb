Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Servers",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Servername = c.String(),
                        .MCServername = c.String(),
                        .Description = c.String(),
                        .Engine = c.String(),
                        .EngineVersion = c.String(),
                        .MCVersion = c.String(),
                        .Hostname = c.String(),
                        .IPAddress = c.String(),
                        .Port = c.Int(nullable := False),
                        .IsUp = c.Boolean(nullable := False),
                        .NumConnections = c.Int(nullable := False),
                        .LastChecked = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
        End Sub
        
        Public Overrides Sub Down()
            DropTable("dbo.Servers")
        End Sub
    End Class
End Namespace
