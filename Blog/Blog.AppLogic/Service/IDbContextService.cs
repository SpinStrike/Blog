using Blog.Data.EF;

namespace Blog.AppLogic.Service
{
    public interface IDbContextService
    {
        BlogDbContext GetDbContextInstance();

        void CloseConnection();
    }
}
