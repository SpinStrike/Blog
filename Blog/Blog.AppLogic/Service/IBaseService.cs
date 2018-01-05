using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    /// <summary>
    /// Represent base functionality for entity services.
    /// </summary>
    public interface IBaseService<T>  where T : EntityDto
    {
        /// <summary>
        /// Select all entities from dataset and return their Dto.
        /// </summary>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Find entity by identifier and return his Dto.
        /// </summary>
        T FindById(Guid id);
    }
}
