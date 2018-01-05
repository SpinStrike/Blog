using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Blog.Data.Model;
using Blog.Data.EF;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent of functionality for work with selected answer dataset.
    /// </summary>
    public class SelectedAnswerRepository : BaseRepository<SelectedAnswer>, ISelectedAnswerRepository
    {
        /// <summary>
        /// Create selected answer repository.
        /// </summary>
        public SelectedAnswerRepository(BlogDbContext context)
            :base(context, context.SelectdAnswers)
        {}

        /// <summary>
        /// Select and return all selected answer in dataset.
        /// </summary>
        public override IEnumerable<SelectedAnswer> FetchAll()
        { 
            return GetDbSet()
                .Include(x => x.Answer)
                .Include(x => x.Question);
        }

        /// <summary>
        /// Find and return selected answer by identifier.
        /// </summary>
        public override SelectedAnswer FindById(Guid id)
        {
            return FetchAll().First(x => x.Id.Equals(id));
        }
    }
}
