using System;
using System.Collections.Generic;
using Blog.Data.Model;

namespace Blog.Data.Repository
{
    /// <summary>
    /// Represent set of base functionality that needed to work with data sources.
    /// </summary>
    /// <typeparam name="T">Type that inherited from BaseEntity.</typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Add entity to data set.
        /// </summary>
        void Add(T t);

        /// <summary>
        /// Find entity in dataset by him identifier.
        /// </summary>
        T FindById(Guid id);

        /// <summary>
        /// Select and return all entities in dataset.
        /// </summary>
        IEnumerable<T> FetchAll();

        /// <summary>
        /// Save all changes in entities dataset.
        /// </summary>
        void Commit();
    }
}
