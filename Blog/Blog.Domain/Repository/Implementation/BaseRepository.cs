using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Blog.Data.EF;
using Blog.Data.Model;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent implemented set of base functionality that needed to work with data sources.
    /// </summary>
    /// <typeparam name="T">Type that inherited from BaseEntity.</typeparam>
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Register data context and dstaset.
        /// </summary>
        public BaseRepository(BlogDbContext context, DbSet<T> dataSet)
        {
            _context = context;
            _dataSet = dataSet;
        }

        /// <summary>
        /// Add entity to dataset.
        /// </summary>
        public void Add(T t)
        {
            _dataSet.Add(t);
        }

        /// <summary>
        /// Select and return all entity in dataset.
        /// </summary>
        public virtual  IEnumerable<T> FetchAll()
        {
            return _dataSet;
        }

        /// <summary>
        /// Find and return entity by identifier.
        /// </summary>
        public virtual T FindById(Guid id)
        {
            return _dataSet.FirstOrDefault(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Seve changes in dataset.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Get data context.
        /// </summary>
        protected BlogDbContext GetContext()
        {
            return _context;
        }

        /// <summary>
        /// Get dataset.
        /// </summary>
        protected DbSet<T> GetDbSet()
        {
            return _dataSet;
        }

        private BlogDbContext _context;
        private DbSet<T> _dataSet;
    }
}
