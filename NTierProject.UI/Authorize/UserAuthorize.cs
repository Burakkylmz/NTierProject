using NTierProject.Model.Option;
using NTierProject.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.UI.Authorize
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]

    public class UserAuthorize : AuthorizeAttribute
    {
        private string[] UserProfilesRequired { get; set; }

        public UserAuthorize(params object[] userProfilesRequired)
        {

            if (userProfilesRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("userProfilesRequired");

            this.UserProfilesRequired = userProfilesRequired.Select(p => Enum.GetName(p.GetType(), p)).ToArray();

        }

        public override void OnAuthorization(AuthorizationContext context)
        {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                var url = new UrlHelper(context.RequestContext);
                var logonUrl = url.Action("Login", "Home", new { Area = "" });
                context.Result = new RedirectResult(logonUrl);

                return;
            }

            bool authorized = false;

            AppUserService _appUserService = new AppUserService();

            AppUser user = _appUserService.FindByUserName(HttpContext.Current.User.Identity.Name);
            string userRole = Enum.GetName(typeof(Role), user.Role);

            foreach (var role in this.UserProfilesRequired)
                if (userRole == role)
                {
                    authorized = true;
                    break;
                }

            if (!authorized)
            {
                var url = new UrlHelper(context.RequestContext);
                var logonUrl = url.Action("Page403", "Error", new { Area = "" });
                //var logonUrl = url.Action("Login", "Account", new { Id = 302, Area = "" });
                context.Result = new RedirectResult(logonUrl);

                return;
            }
        }

    }
}