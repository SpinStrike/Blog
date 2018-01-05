using System;
using Blog.Data.EF;

namespace Blog.AppLogic.Service.Implementation
{
    /// <summary>
    /// Base abstruct service for other service. Responsible for releasing context's resources.
    /// </summary>
    public class BaseService 
    {
        protected BlogDbContext context;
    }
}
