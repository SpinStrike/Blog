using Blog.Data.EF;

namespace Blog.AppLogic.Service
{
    public static class DbSetService
    {
        public static void SetDbIfItNeeded()
        {
            using (var context = new BlogDbContext("BlogDbConnection"))
            { }
        }
    }
}
