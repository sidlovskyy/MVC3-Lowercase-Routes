using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvc3LowercaseRoutes
{
    internal class LowercaseRouteDecorator : RouteBase, IRouteWithArea
    {
        private readonly RouteBase _innerRoute;

        public LowercaseRouteDecorator(RouteBase innerRoute)
        {
            _innerRoute = innerRoute;
        }

        public RouteBase InnerRoute
        {
            get { return _innerRoute; }
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            return _innerRoute.GetRouteData(httpContext);
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            VirtualPathData path = _innerRoute.GetVirtualPath(requestContext, values);

            if (path != null && path.VirtualPath != null)
            {
                string virtualPath = path.VirtualPath;
                path.VirtualPath = ToLowerVirtualPath(virtualPath);
            }

            return path;
        }

        private static string ToLowerVirtualPath(string virtualPath)
        {
            var lastIndexOf = virtualPath.LastIndexOf("?", StringComparison.OrdinalIgnoreCase);

            if (lastIndexOf < 0)
            {
                return virtualPath.ToLowerInvariant();
            }

            string path = virtualPath.Substring(0, lastIndexOf).ToLowerInvariant();
            string query = virtualPath.Substring(lastIndexOf);
            return path + query;
        }

        public string Area
        {
            get
            {
                string area = GetAreaToken(_innerRoute);
                return area;
            }
        }

        private string GetAreaToken(RouteBase routeBase)
        {
            var route = routeBase as Route;
            if (route == null || route.DataTokens == null)
            {
                return null;
            }
            return route.DataTokens["area"] as string;
        }
    }
}
