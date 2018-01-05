using System;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    /// <summary>
    ///  Presents functionality for work with Reviews.
    /// </summary>
    public interface IReviewService : IBaseService<ReviewDto>
    {
        /// <summary>
        /// Create new review entity and add it to dataset. 
        /// </summary>
        void Create(string text, string author, DateTime date);
    }
}
