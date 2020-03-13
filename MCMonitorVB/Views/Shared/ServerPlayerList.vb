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
Imports Newtonsoft.Json.Linq

' Class to maintain a historical list of players that have joined for a server
'	Instantiated per server and tracks player with timestamp
Public Class ServerPlayerList

	Private ReadOnly playerList As New SortedList()

	Public Sub New()
	End Sub

	' Add a player to the list
	Public Sub Add(ByVal player As String)
		' if list is currently full, then remove oldest
		If playerList.Count = GlobalVariables.MAXPLAYERSTORE Then
			playerList.RemoveAt(0)
		End If
		playerList.Add(DateTime.Now.ToString("MM/dd HH:mm:ss.fffff"), player)
	End Sub

	' Add players from a JSON array
	Public Sub Add(ByRef jlist As JArray)
		For Each item As JObject In jlist
			Add(CType(item.Item("name"), String))
		Next
	End Sub

	' Return a concatenated player and timestamp string
	Public Function GetPlayerListConcat() As List(Of String)
		Dim concatenatedList = New List(Of String)
		For Each key In playerList.Keys
			concatenatedList.Add(playerList(key) & " @ " & key.substring(0, key.IndexOf(".")))
		Next
		Return concatenatedList
	End Function

	' Return the latest player from list with timestamp
	Public Function GetLatestPlayerConcat() As String
		If playerList.Count > 0 Then
			Return playerList.GetByIndex(playerList.Count - 1) & " @ " & playerList.GetKey(playerList.Count - 1).substring(0, playerList.GetKey(playerList.Count - 1).IndexOf("."))
		Else
			Return "no data"
		End If
	End Function

	' Remove a player from the list
	Public Sub Remove(ByVal player As String)
		For Each key In playerList.Keys
			If playerList(key) = player Then
				playerList.Remove(key)
			End If
		Next
	End Sub

	' Return a count of players in the list (redundant as this class should hold a fixed number)
	Public Function Count() As Integer
		Return playerList.Count
	End Function

	' Clear out complete list
	Public Sub Clear()
		System.Diagnostics.Debug.WriteLine("debug - cleared playerlist")
		playerList.Clear()
	End Sub

	'Perform a full sync up between actual players and recorded list
	Public Sub SyncList(ByRef jlist As JArray)
		' add players on server and missing from tracker - e.g
		'	when starting monitoring for the first time and players are on
		For Each item As JObject In jlist
			If Not playerList.ContainsValue(CType(item.Item("name"), String)) Then
				Add(CType(item.Item("name"), String))
			End If
		Next
		' debug dump
		For Each key In playerList.Keys
			System.Diagnostics.Debug.WriteLine("debug - " & key & " @ " & playerList(key))
		Next
	End Sub
End Class
