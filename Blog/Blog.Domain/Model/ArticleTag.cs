using System.Collections.Generic;

namespace Blog.Data.Model
{
    public class ArticleTag : BaseEntity
    {
        public string Text { get; set; }

        public List<Article> Articles { get; set; }
    }
}
