using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using Blog.Data.Model;
using Blog.Data.EF;

namespace Blog.Data.Repository.Implementation
{
    public class ArticleTagRepository : BaseRepository<ArticleTag>, IArticleTagRepository
    {
        public ArticleTagRepository(BlogDbContext context)
            :base(context, context.Tags)
        {}

        public override ArticleTag FindById(Guid id)
        {
            return GetDbSet()
                .Include(x => x.Articles)
                .FirstOrDefault(x => x.Id.Equals(id));
        }

        public IEnumerable<ArticleTag> LoadandSelectMany(List<string> tags)
        {
            var articleTags = GetDbSet().Where(x => tags.Contains(x.Text)).ToList();

            tags.RemoveAll(x => articleTags.Select(y => y.Text).Contains(x));

            tags.ForEach(x => articleTags.Add(new ArticleTag() { Text = x }));

            return articleTags;
        }
    }
}
