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

    Private db As New MCMonitorDbContext
    Dim logincookie As CookieContainer

    Structure JSONList
        Dim Name, Email As String
        Dim Age As Integer
    End Structure

    Public Sub New()
        For Each dbServer In db.Servers
            REM Dim result As String = getServerStatus(dbServer.IPAddress, dbServer.Port)
            Dim result As String = getServerStatus(dbServer.IPAddress, dbServer.Port)
            System.Diagnostics.Debug.WriteLine("Debug - result:")
            System.Diagnostics.Debug.WriteLine(result)
            System.Diagnostics.Debug.WriteLine("debug - length = " + result.Length.ToString)
            Dim jsondata = New JObject
            Try
                jsondata = JObject.Parse(result)
                dbServer.IsUp = True
                dbServer.NumConnections = jsondata.SelectToken("players").SelectToken("online")
            Catch
                dbServer.IsUp = False
                dbServer.NumConnections = 0
            End Try
            REM Dim jsonobj = JsonConvert.DeserializeObject(result)
            dbServer.LastChecked = DateAndTime.Now
        Next
        db.SaveChanges()
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

    Private Function getServerStatus(ByVal ipaddr As String, ByVal port As Integer) As String
        Dim encoding As New UTF8Encoding
        Dim tempCookies As New CookieContainer
        Dim byteData As Byte() = encoding.Default.GetBytes("ip=" + ipaddr + "&port=" + CStr(port))
        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://ob-mc.net/PHP-Minecraft-Query-master/serverping.php"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.ContentType = "application/x-www-form-urlencoded"
        postReq.CookieContainer = tempCookies
        postReq.Referer = "https://ob-mc.net/PHP-Minecraft-Query-master/serverping.php"
        postReq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64, rv:26.0) Gecko/20100101 Firefox/26.0"
        postReq.ContentLength = byteData.Length

        Dim postreqstream As Stream = postReq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()

        Dim status As String = ""
        Dim postresponse As HttpWebResponse
        postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        tempCookies.Add(postresponse.Cookies)
        logincookie = tempCookies
        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        status = postreqreader.ReadToEnd()

        Return status

    End Function

    Function isUP(ByVal id As Integer) As Boolean
        REM TODO: Debug code - Replace with server metadata lookup
        Select Case id
            Case 1 To 5
                isUP = True
            Case 6
                isUP = False
            Case 7 To 11
                isUP = True
            Case 12
                isUP = False
            Case 13 To 18 : isUP = True
            Case Else
                isUP = False
        End Select
    End Function
End Class
