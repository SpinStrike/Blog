using Blog.Data.EF;
using Blog.Data.Model;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent of functionality for work with completed questionnaire dataset.
    /// </summary>
    public class CompletedQuestionnaireRepository : BaseRepository<CompletedQuestionnaire>, ICompletedQuestionnaireRepository
    {
        /// <summary>
        /// Create completed questionnaire repository.
        /// </summary>
        public CompletedQuestionnaireRepository(BlogDbContext context)
            :base(context, context.CompletedQuestionnaires)
        {}
    }
}
