using System;
using System.Collections.Generic;
using Blog.Data.Model;

namespace Blog.Data.Repository
{
    /// <summary>
    /// Represent functionality for work wiht questionnaires dataset.
    /// </summary>
    public interface IQuestionnaireRepository : IBaseRepository<Questionnaire>
    {
        /// <summary>
        /// Add questionnaire to dataset.
        /// </summary>
        Guid AddQuestion(Guid questionnaireId,
            string text, 
            bool isFewAnswers, 
            IEnumerable<string> answers);

        /// <summary>
        /// Add answer to one of the question in questionnaire.
        /// </summary>
        void AddAnswerToQuestion(Guid questionnaireId,
            Guid questionId,
            string text);
    }
}
