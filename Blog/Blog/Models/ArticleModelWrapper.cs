using System.Collections.Generic;

namespace Blog.Models
{
    public class ArticleModelWrapper : ModelWrapper<IEnumerable<string>>
    {
        public Article Article { get; set; } = new Article();
    }
}