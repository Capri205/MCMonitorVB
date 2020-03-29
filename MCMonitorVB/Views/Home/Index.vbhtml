@ModelType IEnumerable(Of MCMonitorVB.Models.Server)

@Code
	Dim currEngine = "NaN"
	If GlobalVariables.playalarmsound = True Then
		@<audio src="/sounds/alarm.wav" autoplay="autoplay" preload="auto"></audio>
	ElseIf GlobalVariables.playjoinsound Then
		GlobalVariables.playleavesound = False
		@<audio src="/sounds/joined.wav" autoplay="autoplay" preload="auto"></audio>
	elseif GlobalVariables.playleavesound Then
		GlobalVariables.playjoinsound = False
		@<audio src="/sounds/departed.wav" autoplay="autoplay" preload="auto"></audio>
	End If
	ViewData("Title") = "Home Page"
End Code

<meta http-equiv="refresh" content="30">

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
				PlayerJoinHistory
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
					@If item.MaintenanceMode Then
						@<text>(m)</text>
					End If
				</td>
				<td>
					@If item.IsUp Then
						@<img src="/images/green_check_mark_circle.png" style="width:40px;height:40px" />
					Else
						If Not item.MaintenanceMode Then
							@<div Class="blinking">
								<img src="/images/red_batsu_mark_circle.png" style="width:40px;height:40px" />
							</div>
						Else
							@<img src = "/images/red_batsu_mark_circle.png" style="width:40px;height:40px" />
						End If
					End If
				</td>
				<td>
					@If GlobalVariables.jointrackerDirection(item.Servername) = "Up" Then
						@<p class="blinking">
							<span style="color:green; font:bold">
								@Html.DisplayFor(Function(modelItem) item.NumConnections)
							</span>
						</p>
					ElseIf GlobalVariables.jointrackerDirection(item.Servername) = "Down" Then
						@<p class="blinking">
							<span style="color:red; font:bold">
								@Html.DisplayFor(Function(modelItem) item.NumConnections)
							</span>
						</p>
					Else
						@Html.DisplayFor(Function(modelItem) item.NumConnections)
					End If
				</td>
				<td>
					@Html.DisplayFor(Function(modelItem) item.LastChecked)
				</td>
				<td>
					<font style="font-size:10px">
						@Code
							Dim count = 0
						End Code
						@For Each entry In GlobalVariables.serverPlayerTracker.Item(item.Servername).GetPlayerListConcat()
							If count = 0 Then
								If GlobalVariables.jointrackerDirection(item.Servername) = "Up" Then
									@<span style="color:mediumvioletred">
										@entry
									</span>
									' player who left isn't necessarily the last one who joined, so this is invalid
									'ElseIf GlobalVariables.jointrackerDirection(item.Servername) = "Down" Then
									'	@<span style="color:indigo">
									'		@entry
									'	</span>
								Else
									@entry
								End If
							Else
								@<br>
								@entry
							End If
							@code
								count = count + 1
							End Code
						Next
					</font>
				</td>
			</tr>
		Next
	</tbody>
</table>

