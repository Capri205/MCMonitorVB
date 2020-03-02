@ModelType IEnumerable(Of MCMonitorVB.Models.Server)

@Code
	Dim currEngine = "NaN"
	If GlobalVariables.playjoinsound Then
		GlobalVariables.playleavesound = False
        @<audio src="/sounds/joined.wav" autoplay="autoplay" preload="auto"></audio>
	elseif GlobalVariables.playleavesound Then
		GlobalVariables.playjoinsound = False
        @<audio src="/sounds/departed.wav" autoplay="autoplay" preload="auto"></audio>
	End If
	ViewData("Title") = "Home Page"
End Code

<meta http-equiv="refresh" content="30">

<div class="jumbotron">
    <h1>OB-Minecraft</h1>
    <p class="lead">A small network of Minecraft servers that anyone can join and contribute to. Also features PlayerServer's where
    players can create and run their very own server which also includes plugins!</p>
    <p><a href="https://ob-mc.net" class="btn btn-primary btn-lg">Head over to ob-mc.net &raquo;</a></p>
</div>

<h2>Server dashboard</h2>

<table class="table">
    <thead>
        <tr>
            <th>
                @Html.DisplayNameFor(Function(model) model.Servername)
            </th>
            <th>
                Up/Down
            </th>
            <th>
                Players
            </th>
            <th>
                @Html.DisplayNameFor(Function(model) model.LastChecked)
            </th>
            <th>
                LastPlayerToJoin
            </th>
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
            @If currEngine <> item.Engine Then
				If currEngine <> "NaN" Then
                    @<tr>
                        <td style="background-color:lightgray" height="10"></td>
                        <td style="background-color:lightgray"></td>
                        <td style="background-color:lightgray"></td>
                        <td style="background-color:lightgray"></td>
                        <td style="background-color:lightgray"></td>
                    </tr>
				End If
				currEngine = item.Engine
			End If
            @<tr>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.Servername)
                </td>
                <td>
                    @If item.IsUp Then
                        @<img src="/images/green_check_mark_circle.png" width="40px" height="40px" />
					Else
                        @<img src="/images/red_batsu_mark_circle.png" width="40px" height="40px" />
					End If
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.NumConnections)
                </td>
                <td>
                    @Html.DisplayFor(Function(modelItem) item.LastChecked)
                </td>
                <td>
                    @If GlobalVariables.jointrackerDirection(item.Servername) = "Up" Then
                        @<span style="color:mediumvioletred">
                            @GlobalVariables.jointrackerPlayer(item.Servername)
                        </span>
					Else
                        @If GlobalVariables.jointrackerDirection(item.Servername) = "Down" Then
                            @<span style="color:indigo">
                                @GlobalVariables.jointrackerPlayer(item.Servername)
                            </span>
						Else
                            @GlobalVariables.jointrackerPlayer(item.Servername)
						End If
					End If
                </td>
            </tr>
		Next
    </tbody>
</table>

