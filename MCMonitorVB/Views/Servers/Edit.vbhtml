@ModelType MCMonitorVB.Models.Server
@Code
	ViewData("Title") = "Edit"
End Code

<h2>Edit server details</h2>

@Using (Html.BeginForm())
    @Html.AntiForgeryToken()
    
    @<div class="form-horizontal">
	<!--
		<h4>Server</h4>
	-->
	<hr />
	@Html.ValidationSummary(True, "", New With {.class = "text-danger"})
	@Html.HiddenFor(Function(model) model.Id)

	<div class="form-group">
		@Html.LabelFor(Function(model) model.Servername, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.Servername, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Servername, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.MCServername, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.MCServername, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.MCServername, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.Description, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.Description, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Description, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.Engine, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.Engine, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Engine, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.EngineVersion, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.EngineVersion, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.EngineVersion, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.MCVersion, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.MCVersion, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.MCVersion, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.Hostname, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.Hostname, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Hostname, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.IPAddress, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.IPAddress, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.IPAddress, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.Port, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.Port, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.Port, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		@Html.LabelFor(Function(model) model.MaintenanceMode, htmlAttributes:=New With {.class = "control-label col-md-2"})
		<div class="col-md-10">
			@Html.EditorFor(Function(model) model.MaintenanceMode, New With {.htmlAttributes = New With {.class = "form-control"}})
			@Html.ValidationMessageFor(Function(model) model.MaintenanceMode, "", New With {.class = "text-danger"})
		</div>
	</div>

	<div class="form-group">
		<div class="col-md-offset-2 col-md-10">
			<input type="submit" value="Save" class="btn btn-default" />
		</div>
	</div>
</div>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>

@Section Scripts 
    @Scripts.Render("~/bundles/jqueryval")
End Section
