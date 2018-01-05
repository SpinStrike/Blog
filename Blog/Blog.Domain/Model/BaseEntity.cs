using System;

namespace Blog.Data.Model
{
    /// <summary>
    /// Base class for each  entities in model.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Unique identifier  for entity. Used like primary key.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
