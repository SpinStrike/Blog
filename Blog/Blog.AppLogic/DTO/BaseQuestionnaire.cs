using System.Collections.Generic;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Base abstruct class for creating questionnaires data transfer objects.
    /// </summary>
    public abstract class BaseQuestionnaire<T> : EntityDto where T : AnswerDto
    {
        /// <summary>
        /// Questionnaire title/name.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// List of all queston in questionnaire.
        /// </summary>
        public List<QuestionDto<T>> Questions { get; set; } = new List<QuestionDto<T>>();
    }
}
