using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DataLayer.Repository
{
        public class AdminPanelAuthorizeAttribute : AuthorizeAttribute
        {
            protected override bool AuthorizeCore(HttpContextBase httpContext)
            {
        
            try
            {
                if (httpContext.Session["UserId"].ToString() == Roles)
                {
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                return false;
            }
        }

            protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
            {
                if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult($"/Home/Login");
                }
            }
        }
}