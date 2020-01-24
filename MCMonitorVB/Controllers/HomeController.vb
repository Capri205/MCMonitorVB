Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
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


    Function isUP(ByVal id As Integer) As Boolean
        REM TODO: Debug code - Replace() with server metadata lookup
        Select Case id
            Case 1 To 5
                Return True
            Case 6
                Return False
            Case 7 To 11
                Return True
            Case 12
                Return False
            Case 13 To 18 : Return True
            Case Else
                Return False
        End Select
    End Function
End Class
