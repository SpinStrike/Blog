using System;
using System.Collections.Generic;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service
{
    /// <summary>
    /// Presents functionality for work with questionnaires as set of data.
    /// </summary>
    public interface IQuestionnaireInteractionService 
    {
        /// <summary>
        /// Save user questionnaire answers into dataset.
        /// </summary>
        void AddCompletedQuestionnaire(Guid questionnaireId, IEnumerable<Guid> answers);

        /// <summary>
        /// Get statistic by all question in selected questionnaire.
        /// </summary>
        QuestionnaireStatisticDto QuestionnaireStatistic(Guid questionnaireId);
    }
}
