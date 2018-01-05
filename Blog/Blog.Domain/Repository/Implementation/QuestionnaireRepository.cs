using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Blog.Data.Model;
using Blog.Data.EF;

namespace Blog.Data.Repository.Implementation
{
    /// <summary>
    /// Represent of functionality for work with questionnaire dataset.
    /// </summary>
    public class QuestionnaireRepository : BaseRepository<Questionnaire>, IQuestionnaireRepository
    {
        /// <summary>
        /// Create questionnaire repository.
        /// </summary>
        public QuestionnaireRepository(BlogDbContext context)
            :base(context, context.Questionnaires)
        {}

        /// <summary>
        /// Select and return all questionnaire in dataset.
        /// </summary>
        public override IEnumerable<Questionnaire> FetchAll()
        {
            return GetDbSet()
                .Include(x => x.Questions.Select(y => y.Answers));
        }

        /// <summary>
        /// Find and return questionnaire by identifier.
        /// </summary>
        public override Questionnaire FindById(Guid id)
        {
            return GetDbSet()
                .Include(x => x.Questions.Select(y => y.Answers))
                .First(x => x.Id.Equals(id));
        }

        /// <summary>
        /// Add questionnaire to dataset.
        /// </summary>
        public void AddAnswerToQuestion(Guid questionnaireId, Guid questionId, string text)
        {
            GetDbSet()
                .First(x => x.Id.Equals(questionnaireId))
                    .Questions.First(y => y.Id.Equals(questionId))
                        .Answers.Add(new Answer() { Text = text });
        }

        /// <summary>
        /// Add answer to one of the question in questionnaire.
        /// </summary>
        public Guid AddQuestion(Guid questionnaireId, string text, bool isFewAnswers, IEnumerable<string> answers)
        {
            var question = new Question() { Text = text, IsFewAnswers = isFewAnswers };

            var questionnaire = GetDbSet().First(x => x.Id.Equals(questionnaireId));
            questionnaire.Questions.Add(question);

            var answersToAdd = answers.Select(x => new Answer() { Text = x });
            questionnaire.Questions.Last().Answers.AddRange(answersToAdd);

            return question.Id;
        }
    }
}
