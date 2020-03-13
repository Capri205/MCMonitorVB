Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports MCMonitorVB.Models

Namespace Controllers
    Public Class ServersController
        Inherits System.Web.Mvc.Controller

        Private ReadOnly db As New MCMonitorDbContext

        ' GET: Servers
        Function Index() As ActionResult
            Return View(db.Servers.ToList())
        End Function

        ' GET: Servers/Details/5
        Function Details(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim server As Server = db.Servers.Find(id)
            If IsNothing(server) Then
                Return HttpNotFound()
            End If
            Return View(server)
        End Function

        ' GET: Servers/Create
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Servers/Create
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Create(<Bind(Include:="Id,Servername,MCServername,Description,Engine,EngineVersion,MCVersion,Hostname,IPAddress,Port")> ByVal server As Server) As ActionResult
            If ModelState.IsValid Then
                db.Servers.Add(server)
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(server)
        End Function

        ' GET: Servers/Edit/5
        Function Edit(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim server As Server = db.Servers.Find(id)
            If IsNothing(server) Then
                Return HttpNotFound()
            End If
            Return View(server)
        End Function

        ' POST: Servers/Edit/5
        'To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        'more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Function Edit(<Bind(Include:="Id,Servername,MCServername,Description,Engine,EngineVersion,MCVersion,Hostname,IPAddress,Port,,,")> ByVal server As Server) As ActionResult
            If ModelState.IsValid Then
                db.Entry(server).State = EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(server)
        End Function

        ' GET: Servers/Delete/5
        Function Delete(ByVal id As Integer?) As ActionResult
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim server As Server = db.Servers.Find(id)
            If IsNothing(server) Then
                Return HttpNotFound()
            End If
            Return View(server)
        End Function

        ' POST: Servers/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Function DeleteConfirmed(ByVal id As Integer) As ActionResult
            Dim server As Server = db.Servers.Find(id)
            db.Servers.Remove(server)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
