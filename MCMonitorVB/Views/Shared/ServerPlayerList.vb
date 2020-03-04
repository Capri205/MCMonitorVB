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
Imports GlobalVariables

' Class to maintain a historical list of players that have joined for a server
'	Instantiated per server and tracks player with timestamp
Public Class ServerPlayerList

	Private playerList As New SortedList()

	Public Sub New()
	End Sub

	' Add a player to the list
	Public Sub Add(ByVal player As String)
		' if list is currently full, then remove oldest
		If playerList.Count = GlobalVariables.MAXPLAYERSTORE Then
			playerList.RemoveAt(0)
		End If
		System.Diagnostics.Debug.WriteLine("debug - adding player " & player)
		playerList.Add(DateTime.Now.ToString("MM/dd HH:mm:ss.fffff"), player)
	End Sub

	' Add players from a JSON array
	Public Sub Add(ByRef jlist As JArray)
		For Each item As JObject In jlist
			Add(CType(item.Item("name"), String))
		Next
	End Sub

	' Return a concatenated player and timestamp string
	Public Function GetPlayerListConcat()
		Dim concatenatedList = New ArrayList()
		For Each key In playerList.Keys
			concatenatedList.Add(playerList(key) & " @ " & key.substring(0, key.IndexOf(".")))
		Next
		Return concatenatedList
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
		' convert the json array to arraylist - might be a better way of doing this.
		Dim in_playerlist As New ArrayList()
		For Each item As JObject In jlist
			System.Diagnostics.Debug.WriteLine("debug - currentlist add " & CType(item.Item("name"), String))
			in_playerlist.Add(CType(item.Item("name"), String))
		Next
		' add misisng players - multiple might have joined since we last checked
		'	some might have left also in the interim... cant catch them all with this
		'	style of monitoring - requires server side plugin to do that.
		For Each addplayer In in_playerlist
			If Not playerList.ContainsValue(addplayer) Then
				Add(addplayer)
			End If
		Next
		' remove anyone who's left - can't update the list directly from foreach loop, so
		'	save off those we need to remove to a separate list and delete afterwards
		Dim removeList As New ArrayList()
		For Each key In playerList.Keys
			System.Diagnostics.Debug.WriteLine("debug - checking " & playerList(key) & " is in list")
			If Not in_playerlist.Contains(playerList(key)) Then
				System.Diagnostics.Debug.WriteLine("debug - removing " & playerList(key) & " from list")
				removeList.Add(key)
			End If
		Next
		For Each playerkey In removeList
			playerList.Remove(playerkey)
		Next
		' debug dump
		For Each key In playerList.Keys
			System.Diagnostics.Debug.WriteLine("debug - " & key & " @ " & playerList(key))
		Next

	End Sub
End Class
