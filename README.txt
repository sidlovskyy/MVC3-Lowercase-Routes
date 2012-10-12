Small and very easy to use (one line of code) library which allows to lowercase urls in ASP.NET MVC 3.
To use it you should refference it from your project and add next line in Global.asax after all areas are registered:

protected void Application_Start()
{
	AreaRegistration.RegisterAllAreas();

	RegisterGlobalFilters(GlobalFilters.Filters);
	RegisterRoutes(RouteTable.Routes);

	//make all routes lowercase
	RouteTable.Routes.ToLowercase();
}

Before:
	http://mydomain.com/Home/TestRoute?Param=Test
After:
	http://mydomain.com/home/testroute?Param=Test

It supports areas as well.

For ASP.NET MVC 4 you should probably use out of the box feature. 
	routes.LowercaseUrls = true;