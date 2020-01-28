@ModelType IEnumerable(Of MCMonitorVB.Models.Server)

@Code
    ViewData("Title") = "Home Page"
End Code

<meta http-equiv="refresh" content="30">

<div class="jumbotron">
    <h1>ASP.NET</h1>
    <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS and JavaScript.</p>
    <p><a href="https://asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
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
        </tr>
    </thead>
    <tbody>
        @For Each item In Model
        @<tr>
            <td>
                @Html.DisplayFor(Function(modelItem) item.Servername)
            </td>
            <td>
				@If item.IsUp Then
                    @<img src = "/images/green_check_mark_circle.png" width="40px" height="40px" />
				Else
                    @<img src = "/images/red_batsu_mark_circle.png" width="40px" height="40px" />
				End If
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.NumConnections)
            </td>
            <td>
                @Html.DisplayFor(Function(modelItem) item.LastChecked)
            </td>
        </tr>
		Next
    </tbody>
</table>
