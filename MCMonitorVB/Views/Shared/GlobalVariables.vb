Public Class GlobalVariables
	' Use for tracking players joining
	Public Shared jointrackerConCnt = New Hashtable()
	Public Shared jointrackerPlayer = New Hashtable()
	Public Shared serverPlayerTracker = New Dictionary(Of String, Object)
	Public Shared jointrackerDirection = New Hashtable()
	' Use for triggering a client side sound
	Public Shared playjoinsound As Boolean
	Public Shared playleavesound As Boolean
	Public Shared playserverdownalarm As Boolean
	Public Const MAXPLAYERSTORE As Integer = 5
End Class
