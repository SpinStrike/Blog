using System.Collections.Generic;
using Blog.Data.Model;

namespace Blog.Data.Repository
{
    public interface IArticleTagRepository : IBaseRepository<ArticleTag>
    {
        IEnumerable<ArticleTag> LoadandSelectMany(List<string> tags);
    }
}
