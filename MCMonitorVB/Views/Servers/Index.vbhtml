@ModelType IEnumerable(Of MCMonitorVB.Models.Server)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
	<tr>
		<th>
			@Html.DisplayNameFor(Function(model) model.Servername)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.MCServername)
		</th>
		<!--
				<th>
					@Html.DisplayNameFor(Function(model) model.Description)
				</th>
		-->
		<th>
			@Html.DisplayNameFor(Function(model) model.Engine)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.EngineVersion)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.MCVersion)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.Hostname)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.IPAddress)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.Port)
		</th>
		<th>
			@Html.DisplayNameFor(Function(model) model.MaintenanceMode)
		</th>
		<th></th>
	</tr>

	@For Each item In Model
		@<tr>
			<td>
				@Html.DisplayFor(Function(modelItem) item.Servername)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.MCServername)
			</td>
			<!--
					<td>
						@Html.DisplayFor(Function(modelItem) item.Description)
					</td>
			-->
			<td>
				@Html.DisplayFor(Function(modelItem) item.Engine)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.EngineVersion)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.MCVersion)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.Hostname)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.IPAddress)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.Port)
			</td>
			<td>
				@Html.DisplayFor(Function(modelItem) item.MaintenanceMode)
			<td>
				@Html.ActionLink("Edit", "Edit", New With {.id = item.Id}) |
				@Html.ActionLink("Details", "Details", New With {.id = item.Id}) |
				@Html.ActionLink("Delete", "Delete", New With {.id = item.Id})
			</td>
		</tr>
Next

</table>
