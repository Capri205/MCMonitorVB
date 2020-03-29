@ModelType MCMonitorVB.Models.Server
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Server</h4>
    <hr />
	<dl class="dl-horizontal">
		<dt>
			@Html.DisplayNameFor(Function(model) model.Servername)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.Servername)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.MCServername)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.MCServername)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.Description)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.Description)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.Engine)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.Engine)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.EngineVersion)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.EngineVersion)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.MCVersion)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.MCVersion)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.Hostname)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.Hostname)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.IPAddress)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.IPAddress)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.Port)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.Port)
		</dd>

		<dt>
			@Html.DisplayNameFor(Function(model) model.MaintenanceMode)
		</dt>

		<dd>
			@Html.DisplayFor(Function(model) model.MaintenanceMode)
		</dd>
	</dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Back to List", "Index")
</p>
