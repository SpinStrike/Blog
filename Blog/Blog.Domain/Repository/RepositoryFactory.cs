using Blog.Data.EF;
using Blog.Data.Repository.Implementation;

namespace Blog.Data.Repository
{
    /// <summary>
    /// Represent static methods for creating repositories.
    /// </summary>
    public static class RepositoryFactory
    {
        /// <summary>
        /// Create and return new ArticleRepository.
        /// </summary>
        public static IArticleRepository GetArticleRepository(BlogDbContext context)
        {
            return new ArticleRepository(context);
        }

        /// <summary>
        /// Create and return new ReviewRepository.
        /// </summary>
        public static IReviewRepository GetReviewRepository(BlogDbContext context)
        {
            return new ReviewRepository(context);
        }

        /// <summary>
        /// Create and return new QuestionnaireRepository.
        /// </summary>
        public static IQuestionnaireRepository GetQuestionnaireRepository(BlogDbContext context)
        {
            return new QuestionnaireRepository(context);
        }

        /// <summary>
        /// Create and return new CompletedQuestionnaireRepository.
        /// </summary>
        public static ICompletedQuestionnaireRepository GetCompletedQuestionnaireRepository(BlogDbContext context)
        {
            return new CompletedQuestionnaireRepository(context);
        }

        /// <summary>
        /// Create and return new SelectedAnswerRepository.
        /// </summary>
        public static ISelectedAnswerRepository GetSelectedAnswerRepository(BlogDbContext context)
        {
            return new SelectedAnswerRepository(context);
        }

        public static IVotingRepository GetVotingRepository(BlogDbContext context)
        {
            return new VotingRepository(context);
        }

        public static IArticleTagRepository GetArticleTagRepository(BlogDbContext context)
        {
            return new ArticleTagRepository(context);
        }
    }
}
