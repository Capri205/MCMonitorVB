Public Class GlobalVariables
	' Use for tracking players joining
	Public Shared jointrackerConCnt = New Hashtable()
	Public Shared jointrackerPlayer = New Hashtable()
	Public Shared jointrackerDirection = New Hashtable()
	' Use for triggering a client side sound
	Public Shared playjoinsound As Boolean
	Public Shared playleavesound As Boolean
End Class
