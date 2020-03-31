Public Class GlobalVariables
	' Use for tracking players joining
	Public Shared jointrackerConCnt = New Dictionary(Of String, Integer)
	Public Shared serverPlayerTracker = New Dictionary(Of String, Object)
	Public Shared jointrackerDirection = New Dictionary(Of String, String)
	Public Shared eventcountTracker = New Dictionary(Of String, Integer)
	' Use for triggering a client side sound -alarm has priority and join has priority over leave
	Public Shared playalarmsound As Boolean
	Public Shared playjoinsound As Boolean
	Public Shared playleavesound As Boolean
	Public Const MAXPLAYERSTORE As Integer = 5
	Public Const MAXCHECKSB4ALARM As Integer = 3
	Public Shared trackerFilePosition As Long = 0
End Class
