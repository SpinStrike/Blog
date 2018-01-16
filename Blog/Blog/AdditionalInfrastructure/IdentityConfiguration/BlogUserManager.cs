using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Blog.Data.EF;
using Blog.Data.Model;

namespace Blog.AdditionalInfrastructure.IdentityConfiguration
{
    public class BlogUserManager : UserManager<User>
    {
        public BlogUserManager(IUserStore<User> userStore)
            :base(userStore)
        { }

        public static BlogUserManager Create(IdentityFactoryOptions<BlogUserManager> options,
            IOwinContext context)
        {
            var dataBase = context.Get<BlogDbContext>();
            var manager = new BlogUserManager(new UserStore<User>(dataBase));

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true,
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
            };

            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            return manager;
        }
    }
}