using Blog.Data.Model;
using Blog.Data.EF;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent of functionality for work with review dataset.
    /// </summary>
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        /// <summary>
        /// Create review repository.
        /// </summary>
        public ReviewRepository(BlogDbContext context)
            : base(context, context.Reviews)
        {}
    }
}
