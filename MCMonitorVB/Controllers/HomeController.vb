Imports System
Imports System.Data
Imports System.Data.Entity
Imports System.IO
Imports System.Dynamic
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MCMonitorVB.Models
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private ReadOnly db As New MCMonitorDbContext
    ReadOnly logincookie As CookieContainer
    ReadOnly querytype As String = "ping"
    Public Declare Function GetTickCount Lib "kernel32" () As Long

    Public Sub New()

        GlobalVariables.playjoinsound = False
        GlobalVariables.playleavesound = False
        GlobalVariables.playalarmsound = False

        ' Retrieve updated player join and leave events produced by the Bungeecord OBMetaProducer plugin
        Dim playerupdates As String = GetPlayerUpdates("MCMonitor")
        'System.Diagnostics.Debug.WriteLine("debug - playerupdates=" & playerupdates)
        Dim playerupdatesjson = JArray.Parse(playerupdates)
        'System.Diagnostics.Debug.WriteLine("debug - playerupdates has " & playerupdatesjson.Count() & " entries")

        ' Iterate over our server list and make calls to the server for data and process player join and leave events for that server
        For Each dbServer In db.Servers

            'System.Diagnostics.Debug.WriteLine("debug -----------------------------------------")
            ' Add our server to the global tracker list of not already there
            If Not GlobalVariables.serverPlayerTracker.ContainsKey(dbServer.Servername) Then
                GlobalVariables.serverPlayerTracker.Add(dbServer.Servername, New ServerPlayerList())
                'System.Diagnostics.Debug.WriteLine("debug - adding " & dbServer.Servername & " tracker")
            End If
            If Not GlobalVariables.eventcountTracker.ContainsKey(dbServer.Servername) Then
                GlobalVariables.eventcountTracker.Add(dbServer.Servername, 0)
            End If


            ' Assume no change from prior check - determines sounds to play and possibly other things later
            GlobalVariables.jointrackerDirection(dbServer.Servername) = "NoChange"

            ' Query the server for version data etc and process it
            Dim result As String = GetServerStatus(dbServer.IPAddress, dbServer.Port, dbServer.Engine)
            'System.Diagnostics.Debug.WriteLine("debug - result=" & result)

            Dim jsondata = New JObject
            Try
                jsondata = JObject.Parse(result)
                ' TODO: Check jsondata has something
                dbServer.IsUp = True
                GlobalVariables.eventcountTracker.Item(dbServer.Servername) = 0
                If dbServer.Engine = "Source" Then
                    '
                    ' SOURCE
                    '

                    ' {"Protocol":17,"HostName":"OB-CounterStrike","Map":"cs_militia","ModDir":"csgo",
                    '  "ModDesc":"Counter-Strike: Global Offensive","AppID":730,"Players":0,"MaxPlayers":30,"Bots":0,
                    '  "Dedicated":"d","Os":"l","Password":false,"Secure":true,"Version":"1.37.4.0",
                    '  "ExtraDataFlags":161,"GamePort":27015,"GameTags":"empty,secure","GameID":730}

                    ' {"Protocol":17,"HostName":"OB-GMod Server - PVP Sandbox * M9K|Simfp|Gredwitch|LFS| NoRank!",
                    '  "Map":"gmod_fort_map","ModDir":"garrysmod","ModDesc":"Sandbox","AppID":4000,"Players":0,"MaxPlayers":16,
                    '  "Bots":0,"Dedicated":"d","Os":"l","Password":false,"Secure":true,"Version":"2019.11.12",
                    '  "ExtraDataFlags":177,"GamePort":27016,"SteamID":90132776141476868,"GameTags":" gm:sandbox","GameID":4000}

                    dbServer.NumConnections = jsondata.SelectToken("Players")
                    If CheckPlayerCountChange(dbServer.Servername, dbServer.NumConnections) Then
                        If GlobalVariables.jointrackerDirection(dbServer.Servername) = "Down" Then
                            GlobalVariables.playleavesound = True
                        End If
                        If GlobalVariables.jointrackerDirection(dbServer.Servername) = "Up" Then
                            GlobalVariables.playjoinsound = True
                        End If
                    End If

                    If dbServer.EngineVersion <> jsondata.SelectToken("Version") Then
                        dbServer.EngineVersion = jsondata.SelectToken("Version")
                    End If
                Else
                    '
                    ' MINECRAFT
                    '

                    ' {"description": {"text":""},
                    '  "players":{"max":10,"online":1,"sample":[{"id":"175d4ce8-cc2e-47fe-bfa5-89e711c89084","name":"sean_ob"}]},
                    '  "version":{"name":"Spigot 1.15.2","protocol":578},"favicon":"data:image/png;base64,..."}
                    '
                    ' {"description":"",
                    '  "players":{"max":10,"online":0},
                    '  "version":{"name":"1.7.10","protocol":5},
                    '  "modinfo":{"type":"FML",
                    '             "modList":[{"modid":"mcp","version":"9.05"},
                    '                        {"modid":"FML","version":"7.10.99.99"},
                    '                        {"modid":"Forge","version":"10.13.4.1614"},
                    '                        {"modid":"kimagine","version":"0.2"},
                    '                        {"modid":"obmetaproducer","version":"0.1"},
                    '                        {"modid":"OreSpawn","version":"1.7.10.20.2"},
                    '                        {"modid":"worldedit","version":"6.1.1"}
                    '                       ]
                    '            }
                    ' }

                    ' TODO: need to decide to use count from query or count() from actual playertracker updated by player updates
                    dbServer.NumConnections = 0
                    If jsondata IsNot Nothing Then
                        If jsondata.ContainsKey("players") Then
                            dbServer.NumConnections = jsondata.SelectToken("players").SelectToken("online")
                        End If
                    End If

                    ' deterimne player count change and therefore sound to play
                    If CheckPlayerCountChange(dbServer.Servername, dbServer.NumConnections) Then
                        If GlobalVariables.jointrackerDirection(dbServer.Servername) = "Up" Then
                            GlobalVariables.playjoinsound = True
                            If GlobalVariables.jointrackerDirection(dbServer.Servername) = "Down" Then
                                GlobalVariables.playleavesound = True
                            End If
                        End If
                    End If

                    ' process player updates for server
                    For Each item As String In playerupdatesjson
                        'System.Diagnostics.Debug.WriteLine("debug - item = " & item)
                        Dim tokens As String() = item.Split(New Char() {"#"c})
                        'System.Diagnostics.Debug.WriteLine("debug - event=" & tokens(0) & ", player=" & tokens(1) & ", server=" & tokens(2) & ",timestamp=" & tokens(3))
                        If dbServer.Servername.Contains(tokens(2)) Then
                            If tokens(0) = "ServerSwitchEvent" Then
                                GlobalVariables.serverPlayerTracker.Item(dbServer.Servername).Add(tokens(1))
                            End If
                        End If
                    Next

                    ' check to see if players are on the servers, but no data recorded - ie. when starting up the monitoring
                    ' note: we can't add in the order they joined because we dont have that data, so just add them in the order the server gives them to us
                    If dbServer.NumConnections > 0 And GlobalVariables.serverPlayerTracker.Item(dbServer.Servername).Count() = 0 And dbServer.Servername <> "ob-bungee" Then
                        Dim playerlist As JArray = CType(jsondata.SelectToken("players").SelectToken("sample"), JArray)
                        If playerlist IsNot Nothing Then
                            If playerlist.Count() > 0 Then
                                GlobalVariables.serverPlayerTracker.Item(dbServer.Servername).SyncList(playerlist)
                            End If
                        End If
                    End If

                    ' get and update any other information regarding server
                    ' version
                    If jsondata.ContainsKey("version") Then
                        Dim mcversion As String = jsondata.SelectToken("version").SelectToken("name")
                        mcversion = Replace(mcversion, "Spigot ", "", 1)
                        mcversion = Replace(mcversion, "OB-BungeeCord ", "", 1)
                        mcversion = Replace(mcversion, "thermos,cauldron,craftbukkit,mcpc,kcauldron,fml,forge ", "", 1)
                        mcversion = Replace(mcversion, "Forge ", "", 1)
                        If dbServer.MCVersion <> mcversion Then
                            dbServer.MCVersion = mcversion
                        End If
                        ' engine
                        Dim engine As String = ""
                        If jsondata.ContainsKey("modinfo") Then
                            If jsondata.SelectToken("modinfo").SelectToken("type") = "FML" Then
                                engine = jsondata.SelectToken("modinfo").SelectToken("type").ToString
                                Dim modlist As JArray = CType(jsondata.SelectToken("modinfo")("modList"), JArray)
                                For Each item As JObject In modlist
                                    If CType(item("modid"), String) = "Forge" Then
                                        Dim engineversion As String = CType(item("version"), String)
                                        If dbServer.EngineVersion <> engineversion Then
                                            dbServer.EngineVersion = engineversion
                                        End If
                                    End If
                                Next
                            End If
                        Else
                            engine = jsondata.SelectToken("version").SelectToken("name").ToString.Substring(0, jsondata.SelectToken("version").SelectToken("name").ToString.IndexOf(" "))
                        End If
                        If engine <> dbServer.Engine Then
                            dbServer.Engine = engine
                        End If
                    End If
                End If
            Catch
                dbServer.IsUp = False
                dbServer.NumConnections = 0
                If Not dbServer.MaintenanceMode Then
                    If GlobalVariables.eventcountTracker.Item(dbServer.Servername) < GlobalVariables.MAXCHECKSB4ALARM Then
                        GlobalVariables.eventcountTracker.Item(dbServer.Servername) = GlobalVariables.eventcountTracker.Item(dbServer.Servername) + 1
                    Else
                        GlobalVariables.playalarmsound = True
                    End If
                End If
            End Try
            dbServer.LastChecked = DateAndTime.Now
        Next

        Dim dbsave As Boolean = False
        Do
            Try
                db.Database.CommandTimeout = 1000
                db.SaveChanges()
                dbsave = True
            Catch ex As TimeoutException
                Console.WriteLine("Timeout exception in saving database.. retry in 1 second")
                Pause(1000)
            End Try
        Loop While (dbsave <> True)

    End Sub

    Sub Pause(Length As Long)
        Dim OldTime As Long
        OldTime = GetTickCount
        Do
            If GetTickCount >= OldTime + Length Then Exit Do
        Loop
    End Sub

    Function Index() As ActionResult
        Return View(db.Servers.ToList())
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function

    Private Function GetServerStatus(ByVal ipaddr As String, ByVal port As Integer, ByVal servertype As String) As String
        Dim encoding As New UTF8Encoding
        'Dim tempCookies As New CookieContainer
        Dim databytestr As String = ""
        If (servertype = "Source") Then
            databytestr = "svrtype=Source"
        ElseIf (servertype = "Spigot" Or servertype = "Paper" Or servertype = "FML") Then
            databytestr = "svrtype=Minecraft"
        End If
        databytestr = databytestr + "&ip=" & ipaddr & "&port=" & CStr(port)
        Dim byteData As Byte() = encoding.GetBytes(databytestr)
        Dim postReq As HttpWebRequest
        'postReq = DirectCast(WebRequest.Create("https://ob-mc.net/serverquery/query.php"), HttpWebRequest)
        postReq = DirectCast(WebRequest.Create("http://192.168.1.52:80/serverquery/query.php"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.ContentType = "application/x-www-form-urlencoded"
        'postReq.CookieContainer = tempCookies
        'postReq.Referer = "https://ob-mc.net/serverquery/query.php"
        postReq.Referer = "http://192.168.1.52:80/serverquery/query.php"
        'postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64, rv:26.0) Gecko/20100101 Firefox/26.0"
        postReq.ContentLength = byteData.Length

        Dim postreqstream As Stream = postReq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()

        Dim postresponse As HttpWebResponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        'tempCookies.Add(postresponse.Cookies)
        'logincookie = tempCookies
        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        Dim status = postreqreader.ReadToEnd()

        Return status

    End Function

    Private Function GetPlayerUpdates(ByVal qid As String) As String
        Dim encoding As New UTF8Encoding
        Dim databytestr As String = ""
        databytestr = databytestr + "&id=" & qid
        Dim byteData As Byte() = encoding.GetBytes(databytestr)
        Dim postReq As HttpWebRequest
        'postReq = DirectCast(WebRequest.Create("https://ob-mc.net/serverquery/puquery.php"), HttpWebRequest)
        postReq = DirectCast(WebRequest.Create("http://192.168.1.52/serverquery/puquery.php"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.ContentType = "application/x-www-form-urlencoded"
        'postReq.CookieContainer = tempCookies
        'postReq.Referer = "https://ob-mc.net/serverquery/puquery.php"
        postReq.Referer = "http://192.168.1.52/serverquery/puquery.php"
        'postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64, rv:26.0) Gecko/20100101 Firefox/26.0"
        postReq.ContentLength = byteData.Length

        'TODO: Need to handle inability to connect to remote server

        Dim postreqstream As Stream = postReq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()

        Dim postresponse As HttpWebResponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        'tempCookies.Add(postresponse.Cookies)
        'logincookie = tempCookies
        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        Dim updates = postreqreader.ReadToEnd()

        Return updates
    End Function

    Private Function CheckPlayerCountChange(ByVal server As String, ByVal numcons As Integer)
        Dim countchanged As Boolean = False
        If server <> "ob-bungee" Then
            If GlobalVariables.jointrackerConCnt.ContainsKey(server) Then
                If numcons > GlobalVariables.jointrackerConCnt(server) Then
                    countchanged = True
                    GlobalVariables.jointrackerDirection(server) = "Up"
                ElseIf numcons < GlobalVariables.jointrackerConCnt(server) Then
                    countchanged = True
                    GlobalVariables.jointrackerDirection(server) = "Down"
                End If
                GlobalVariables.jointrackerConCnt(server) = numcons
            Else
                GlobalVariables.jointrackerConCnt.Add(server, numcons)
                ' catch case where monitoring just starting and someone is in
                If numcons > 0 Then
                    countchanged = True
                    GlobalVariables.jointrackerDirection(server) = "Up"
                End If
            End If
        End If
        Return countchanged
    End Function

End Class
