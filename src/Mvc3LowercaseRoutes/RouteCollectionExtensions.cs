using System.Web.Routing;

namespace Mvc3LowercaseRoutes
{
    public static class RouteCollectionExtensions
    {
        public static void ToLowercase(this RouteCollection routes)
        {
            for (int i = 0; i < RouteTable.Routes.Count; i++)
            {
                RouteTable.Routes[i] = new LowercaseRouteDecorator(RouteTable.Routes[i]);
            }
        }
    }
}
