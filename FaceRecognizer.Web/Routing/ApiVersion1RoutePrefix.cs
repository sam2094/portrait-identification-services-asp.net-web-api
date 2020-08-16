using System.Web.Http;

namespace FaceRecognizer.Web.Routing
{
    /// <summary>
    /// Configures api versioning for version 1.
    /// </summary>
    public class ApiVersion1RoutePrefix : RoutePrefixAttribute
    {
        private const string RouteBase = "api/v1";
        private const string PrefixRouteBase = RouteBase + "/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="routePrefix"></param>
        public ApiVersion1RoutePrefix(string routePrefix) : base(string.IsNullOrWhiteSpace(routePrefix) ? RouteBase : PrefixRouteBase + routePrefix) { }
    }
}
