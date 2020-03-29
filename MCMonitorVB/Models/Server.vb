Imports System.Data.Entity

Namespace Models
    Public Class Server
        Public Property Id As Integer
        Public Property Servername As String
        Public Property MCServername As String
        Public Property Description As String
        Public Property Engine As String
        Public Property EngineVersion As String
        Public Property MCVersion As String
        Public Property Hostname As String
        Public Property IPAddress As String
        Public Property Port As Integer
        Public Property IsUp As Boolean?
        Public Property NumConnections As Integer?
        Public Property LastChecked As DateTime?
        Public Property MaintenanceMode As Boolean?
    End Class

    Public Class MCMonitorDbContext
        Inherits DbContext
        Public Property Servers As DbSet(Of Server)
    End Class

End Namespace
