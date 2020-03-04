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
                    .MCServername = "OB-Bungeecord",
                    .Description = "Main Proxy for OB-Minecraft",
                    .Engine = "FML",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.52",
                    .Port = 25565,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-lobby",
                    .MCServername = "Main Lobby",
                    .Description = "Main Lobby for OB-Minecraft",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.52",
                    .Port = 26010,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-pvp-lobby",
                    .MCServername = "PVP Lobby",
                    .Description = "Lobby for PVP Servers",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.52",
                    .Port = 26020,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-forge-lobby",
                    .MCServername = "Forge Lobby",
                    .Description = "Lobby for Forge Servers",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.52",
                    .Port = 26030,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-build",
                    .MCServername = "Creative Build",
                    .Description = "Creative build server",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.53",
                    .Port = 26010,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-wildwildwest",
                    .MCServername = "WildWildWest Survival",
                    .Description = "Survival Server with guns!",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc1",
                    .IPAddress = "192.168.1.52",
                    .Port = 26020,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-skywars",
                    .MCServername = "SkyWars",
                    .Description = "Traditional SkyWars server with lots of player built maps",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26030,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-survival",
                    .MCServername = "Survival Games",
                    .Description = "Time based survival games in player built arenas",
                    .Engine = "Spigot",
                    .EngineVersion = "1.13",
                    .MCVersion = "1.13",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26040,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-skyblock",
                    .MCServername = "SkyBlock",
                    .Description = "Traditional SkyBlock game",
                    .Engine = "Spigot",
                    .EngineVersion = "1.12.2",
                    .MCVersion = "1.12.2",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26050,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-skyguns",
                    .MCServername = "SkyGuns",
                    .Description = "SkyWars with guns and RPG's!",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26060,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-bedwars",
                    .MCServername = "Bed Wars",
                    .Description = "Classic BedWars game",
                    .Engine = "Spigot",
                    .EngineVersion = "1.12.2",
                    .MCVersion = "1.12.2",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26070,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-murder",
                    .MCServername = "Murder Mystery",
                    .Description = "The brilliant Murder Mystery game",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26080,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-practice",
                    .MCServername = "Practice",
                    .Description = "Sandbox server for testing",
                    .Engine = "Spigot",
                    .EngineVersion = "1.15.1",
                    .MCVersion = "1.15.1",
                    .Hostname = "ob-mc2",
                    .IPAddress = "192.168.1.53",
                    .Port = 26090,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-orespawn",
                    .MCServername = "Orespawn",
                    .Description = "The legendary Orespawn mod",
                    .Engine = "FML",
                    .EngineVersion = "1.7.10",
                    .MCVersion = "1.7.10",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26010,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-twilight",
                    .MCServername = "Twilight Forest",
                    .Description = "Twilight Forest mod server",
                    .EngineVersion = "1.7.10",
                    .MCVersion = "1.7.10",
                    .Engine = "FML",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26020,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-traincraft",
                    .MCServername = "Traincraft",
                    .Description = "Trains! in Minecraft!",
                    .Engine = "FML",
                    .EngineVersion = "1.7.10",
                    .MCVersion = "1.7.10",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26030,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-rlcraft",
                    .MCServername = "RLCraft",
                    .Description = "Real Life Craft - insanely difficult!",
                    .Engine = "FML",
                    .EngineVersion = "1.7.10",
                    .MCVersion = "1.7.10",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26040,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-pixelmon",
                    .MCServername = "Pixelmon",
                    .Description = "Pokemon mod server",
                    .Engine = "FML",
                    .EngineVersion = "1.12.2",
                    .MCVersion = "1.12.2",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26050,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "ob-lotr",
                    .MCServername = "Lord of the Rings",
                    .Description = "The massive Lord of the Rings - with Hobbits!",
                    .Engine = "FML",
                    .EngineVersion = "1.7.10",
                    .MCVersion = "1.7.10",
                    .Hostname = "ob-mc3",
                    .IPAddress = "192.168.1.54",
                    .Port = 26060,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "OB-CounterStrike",
                    .MCServername = "OB-CounterStrike",
                    .Description = "OB CSGO Server",
                    .Engine = "Source",
                    .EngineVersion = "1",
                    .MCVersion = "1",
                    .Hostname = "ob-st1",
                    .IPAddress = "192.168.1.55",
                    .Port = 26015,
                    .IsUp = False,
                    .NumConnections = 0
                },
                New Server With
                {
                    .Servername = "OB-GMod",
                    .MCServername = "OB-GMod",
                    .Description = "OB Garry's Mod Server",
                    .Engine = "Source",
                    .EngineVersion = "1",
                    .MCVersion = "1",
                    .Hostname = "ob-st1",
                    .IPAddress = "192.168.1.55",
                    .Port = 26016,
                    .IsUp = False,
                    .NumConnections = 0
                }
            }
            servers.ForEach(Function(d) context.Servers.Add(d))
        End Sub
    End Class
End Namespace