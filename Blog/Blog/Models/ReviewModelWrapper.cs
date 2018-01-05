using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.Models
{
    public class ReviewModelWrapper : ModelWrapper<IEnumerable<ReviewDto>>
    {
        public Review Review { get; set; } = new Review();
    }
}