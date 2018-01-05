using System;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Base class to other data transfer objects.
    /// </summary>
    public abstract class EntityDto
    {
        /// <summary>
        /// Unique identifier of data transfer object.
        /// </summary>
        public Guid Id { get; set; }
    }
}
