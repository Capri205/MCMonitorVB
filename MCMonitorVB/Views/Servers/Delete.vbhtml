@ModelType MCMonitorVB.Models.Server
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
	End Using
</div>
