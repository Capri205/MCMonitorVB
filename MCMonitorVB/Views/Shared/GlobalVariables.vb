Public Class GlobalVariables
	' Use for tracking players joining
	Public Shared jointrackerConCnt = New Dictionary(Of String, Integer)
	Public Shared serverPlayerTracker = New Dictionary(Of String, Object)
	Public Shared jointrackerDirection = New Dictionary(Of String, String)
	' Use for triggering a client side sound
	Public Shared playjoinsound As Boolean
	Public Shared playleavesound As Boolean
	Public Shared playserverdownalarm As Boolean
	Public Const MAXPLAYERSTORE As Integer = 5
	Public Shared trackerFilePosition As Long = 0
End Class
