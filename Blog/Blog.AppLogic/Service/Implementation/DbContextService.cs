using System;
using Blog.Data.EF;

namespace Blog.AppLogic.Service.Implementation
{
    public sealed class DbContextService : IDbContextService, IDisposable
    {
        public DbContextService()
        {
            _context = new BlogDbContext("BlogDbConnection");
        }

        public BlogDbContext GetDbContextInstance()
        {
            lock (locker)
            {
                if (_context == null)
                {
                    _context = new BlogDbContext("BlogDbConnection");
                }
            }

            return _context; 
        }

        public void CloseConnection()
        {
            _context.Database.Connection.Close();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose (bool isDispose)
        {
            if(!_isDisposing)
            {
                if (isDispose)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
            _isDisposing = true;
        }

        private BlogDbContext _context;

        private bool _isDisposing = false;

        private object locker = new object();
    }
}
