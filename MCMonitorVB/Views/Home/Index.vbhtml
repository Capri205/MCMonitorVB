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

<div class="row">
    <div class="col-md-4">
        <h2>Getting started</h2>
        <p>
            ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
            enables a clean separation of concerns and gives you full control over markup
            for enjoyable, agile development.
        </p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Get more libraries</h2>
        <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn more &raquo;</a></p>
    </div>
    <div class="col-md-4">
        <h2>Web Hosting</h2>
        <p>You can easily find a web hosting company that offers the right mix of features and price for your applications.</p>
        <p><a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn more &raquo;</a></p>
    </div>
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
