using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Blog.Data.Model;

namespace Blog.AdditionalInfrastructure.IdentityConfiguration
{
    public class BlogSignInManager : SignInManager<User, string>
    {
   
        public BlogSignInManager(BlogUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {}

        public static BlogSignInManager Create(IdentityFactoryOptions<BlogSignInManager> options, IOwinContext context)
        {
            return new BlogSignInManager(context.GetUserManager<BlogUserManager>(), context.Authentication);
        }
    }
}