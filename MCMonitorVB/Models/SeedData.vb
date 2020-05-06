Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports MCMonitorVB.Models

// place some seed data here to get the database started with when running initial setup
    
Namespace MCMonitorVB.Models
    Public Class SeedData
        Inherits DropCreateDatabaseIfModelChanges(Of MCMonitorDbContext)
        Protected Overrides Sub Seed(ByVal context As MCMonitorDbContext)
            Dim servers = New List(Of Server) From {
                New Server With
                {
                    .Servername = "YourServer1",
                    .MCServername = "YourServer1",
                    .Description = "YourServer1-Description",
                    .Engine = "FML",
                    .EngineVersion = "1.15.2",
                    .MCVersion = "1.15.2",
                    .Hostname = "mcserver1",
                    .IPAddress = "192.168.1.2",
                    .Port = 25565,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                },
                New Server With
                {
                    .Servername = "YourServer2",
                    .MCServername = "YourServer2",
                    .Description = "YourServer2-Description",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.2",
                    .MCVersion = "1.15.2",
                    .Hostname = "mcserver2",
                    .IPAddress = "192.168.1.3",
                    .Port = 25570,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                }
            }
            servers.ForEach(Function(d) context.Servers.Add(d))
        End Sub
    End Class
End Namespace
