using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Blog.Data.EF;

namespace Blog.AdditionalInfrastructure.IdentityConfiguration
{
    public class IdentityConfiguration
    {
        public static void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<BlogDbContext>(BlogDbContext.CreateDb);
            app.CreatePerOwinContext<BlogUserManager>(BlogUserManager.Create);
            app.CreatePerOwinContext<BlogSignInManager>(BlogSignInManager.Create); 

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}