using System.Collections.Generic;

namespace Blog.AppLogic.DTO
{
    /// <summary>
    /// Represent Question as Question data transfer object.
    /// </summary>
    public class QuestionDto<T> : EntityDto where T : AnswerDto 
    {
        /// <summary>
        /// Text of question.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Get or set one or few answers can be selected.
        /// </summary>
        public bool IsFewAnswers { get; set; } = false;

        /// <summary>
        /// List of question answers.
        /// </summary>
        public List<T> Answers { get; set; } = new List<T>();
    }
}
