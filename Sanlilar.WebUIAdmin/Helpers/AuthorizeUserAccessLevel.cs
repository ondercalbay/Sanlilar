using System;
using System.Web;
using System.Web.Mvc;

namespace Sanlilar.WebUIAdmin.Helpers
{
    [AttributeUsageAttribute(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class AuthorizeUserAccessLevel : AuthorizeAttribute
    {
        public string UserRole { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);

            if (!isAuthorized)
            {
                return false;
            }
            
            if (this.UserRole.ToUpper().Contains(UserHelper.Kullanici.RolAdi.ToUpper()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                base.HandleUnauthorizedRequest(filterContext);
            }
            else
            {
                ViewDataDictionary dic = new ViewDataDictionary();
                dic.Add("message", "Bu işlemi yapma yetkiniz bulunmamaktadır.");
                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = dic
                };
            }
            //throw new NotAuthorizedHttpException(UserRole);
        }

    }
    public class NotAuthorizedHttpException : HttpException
    {
        public NotAuthorizedHttpException(string missingRoles)
          : base(401, string.Format("Bu alana girebilmek için yetkiniz yok '{0}'.", string.Join(", ", missingRoles)))
        {
        }
    }
}