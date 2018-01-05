using Blog.AppLogic.DTO;

namespace Blog.Models
{
    public class ModelWrapper<T> where T : class
    {
        public T MainContent { get; set; }

        public VotingDto Voting { get; set; } = null;
    }
}