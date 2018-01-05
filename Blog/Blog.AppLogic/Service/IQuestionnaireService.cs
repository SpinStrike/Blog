using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    /// <summary>
    /// Presents functionality for work with questionnaires as entities.
    /// </summary>
    public interface IQuestionnaireService : IBaseService<QuestionnaireDto>
    {
        /// <summary>
        /// Create new questionnaire entity, without questions and answers, and add it to dataset.  
        /// </summary>
        Guid Create(string Titel);

        /// <summary>
        /// Create new question with answers and add it to questionnaire question list.  
        /// </summary>
        void AddQuestion(Guid idQuestionare, 
             string text,
             bool isFewAnswers,
             IEnumerable<string> answers);

        /// <summary>
        /// Create new answer and add to selected question.  
        /// </summary>
        void AddAnswerToQuestion(Guid questionnaireId,
            Guid questionId,
            string text);
    }
}
