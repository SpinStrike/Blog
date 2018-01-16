using Microsoft.Owin;
using Owin;
using Blog.AdditionalInfrastructure.IdentityConfiguration;

[assembly: OwinStartup(typeof(Blog.Startup))]

namespace Blog
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            IdentityConfiguration.Configuration(app);
        }
    }
}
