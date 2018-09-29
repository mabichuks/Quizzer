using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Owin;

[assembly: OwinStartup(typeof(Quizzer.Web.Startup))]

namespace Quizzer.Web
{
    public class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                CookieName = "Quizzer"
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            var facebookAuthenticationOptions = new FacebookAuthenticationOptions();
            facebookAuthenticationOptions.Scope.Add("public_profile");
            facebookAuthenticationOptions.Scope.Add("email");
            facebookAuthenticationOptions.AppId = "240918073264369";
            facebookAuthenticationOptions.AppSecret = "8c7bf4298e43b3b1591a97a11a15625f";
            facebookAuthenticationOptions.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = context =>
                {
                    context.Identity.AddClaim(new System.Security.Claims.Claim("FaceBookAccessToken",
                        context.AccessToken));
                    return Task.FromResult(true);
                }
            };

            facebookAuthenticationOptions.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(facebookAuthenticationOptions);
        }

    }
}
