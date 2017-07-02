using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store.Web.Security
{
    public class AuthorizeUsers: AuthorizeAttribute
    {
        public bool RequireAdmin { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (RequireAdmin)
            {
                if (httpContext.User.Identity.Name != "admin@store.ro")
                {
                    return false;
                }
            }
            var isAthorized = base.AuthorizeCore(httpContext);
            if (!isAthorized)
            {
                return false;
            }


            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(
                            new
                            {
                                controller = "Account",
                                action = "LogIn"
                            })
                        );
        }


    }

}