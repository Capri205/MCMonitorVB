Imports System
Imports System.Collections.Generic
Imports System.Data.Entity
Imports MCMonitorVB.Models


Namespace MCMonitorVB.Models
    Public Class SeedData
        Inherits DropCreateDatabaseIfModelChanges(Of MCMonitorDbContext)
        Protected Overrides Sub Seed(ByVal context As MCMonitorDbContext)
            Dim servers = New List(Of Server) From {
                New Server With
                {
                    .Servername = "BungeeCord",
                    .MCServername = "Bungeecord",
                    .Description = "Main Proxy",
                    .Engine = "FML",
                    .EngineVersion = "",
                    .MCVersion = "",
                    .Hostname = "myhost1",
                    .IPAddress = "192.168.1.10",
                    .Port = 25565,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                },
                New Server With
                {
                    .Servername = "lobby",
                    .MCServername = "Main Lobby",
                    .Description = "Main Lobby",
                    .Engine = "Spigot",
                    .EngineVersion = "",
                    .MCVersion = "",
                    .Hostname = "myhost1",
                    .IPAddress = "192.168.1.10",
                    .Port = 25570,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                },
                New Server With
                {
                    .Servername = "orespawn",
                    .MCServername = "Orespawn",
                    .Description = "The legendary Orespawn",
                    .Engine = "FML",
                    .EngineVersion = "",
                    .MCVersion = "",
                    .Hostname = "myhost2",
                    .IPAddress = "192.168.1.11",
                    .Port = 25575,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                },
                New Server With
                {
                    .Servername = "CounterStrike",
                    .MCServername = "CounterStrike",
                    .Description = "CSGO Server",
                    .Engine = "Source",
                    .EngineVersion = "1",
                    .MCVersion = "1",
                    .Hostname = "myhost3",
                    .IPAddress = "192.168.1.12",
                    .Port = 27015,
                    .IsUp = False,
                    .NumConnections = 0,
                    .MaintenanceMode = False
                }
            }
            servers.ForEach(Function(d) context.Servers.Add(d))
        End Sub
    End Class
End Namespace