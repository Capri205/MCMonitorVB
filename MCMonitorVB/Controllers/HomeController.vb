Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MCMonitorVB.Models

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private db As New MCMonitorDbContext

    Public Sub New()
        For Each dbServer In db.Servers
            System.Diagnostics.Debug.WriteLine("Debug - result = " + getServerStatus(dbServer.IPAddress, dbServer.Port))
            dbServer.IsUp = isUP(dbServer.Id)
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
        Dim postData As Byte() = Encoding.Default.GetBytes("ip=" + ipaddr + "&port=" + CStr(port))
        Dim result As String = sendPost(postData)
        Return result
    End Function

    Private Function sendPost(ByVal p As Byte()) As String
        Dim encoding As New UTF8Encoding
        Dim byteData As Byte() = p
        Dim postReq As HttpWebRequest = DirectCast(WebRequest.Create("https://ob-mc.net/PHP-Minecraft-Query-master/serverping.php"), HttpWebRequest)
        postReq.Method = "POST"
        postReq.KeepAlive = True
        postReq.ContentType = "application/x-www-form-urlencoded"
        postReq.UserAgent = "Mozilla/5.0 (Windows; U; Windows NT 6.1; ru; rv:1.9.2.3) Gecko/20100401 Firefox/4.0 (.NET CLR 3.5.30729)"
        postReq.ContentLength = byteData.Length

        Dim postreqstream As Stream = postReq.GetRequestStream()
        postreqstream.Write(byteData, 0, byteData.Length)
        postreqstream.Close()
        Dim postresponse As HttpWebResponse
        postresponse = DirectCast(postReq.GetResponse(), HttpWebResponse)
        Dim postreqreader As New StreamReader(postresponse.GetResponseStream())
        Return postreqreader.ReadToEnd()
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
