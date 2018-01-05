using System;
using System.Data.Entity;
using System.Linq;
using Blog.Data.EF;
using Blog.Data.Model;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent of functionality for work with article dataset.
    /// </summary>
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        /// <summary>
        /// Create article repository.
        /// </summary>
        public ArticleRepository(BlogDbContext context)
            :base(context, context.Articles)
        {}

        public override Article FindById(Guid id)
        {
            return GetDbSet()
                .Include(x => x.Tags)
                .FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
