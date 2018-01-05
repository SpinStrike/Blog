using System;
using System.Collections.Generic;
using Blog.Data.Model;
using Blog.AppLogic.DTO;
using Blog.Data.EF;
using Blog.Data.Repository;

namespace Blog.AppLogic.Service.Implementation
{
    /// <summary>
    ///  Represent questionnaire for work with articles.
    /// </summary>
    public class QuestionnaireService : BaseService, IQuestionnaireService
    {
        /// <summary>
        /// Create questionnaire service. 
        /// </summary>
        public QuestionnaireService(IDbContextService dbContextService)
        {
            context = dbContextService.GetDbContextInstance();
            _repository = RepositoryFactory.GetQuestionnaireRepository(context);
        }

        /// <summary>
        /// Create new questionnaire entity, without questions and answers, and add it to dataset.  
        /// </summary>
        public Guid Create(string title)
        {
            var questionnaire = new Questionnaire()
            {
                Title = title
            };

            _repository.Add(questionnaire);
            _repository.Commit();

            return questionnaire.Id;
        }

        /// <summary>
        /// Create new question with answers and add it to questionnaire question list.  
        /// </summary>
        public void AddQuestion(Guid idQuestionare, string text, bool isFewAnswers, IEnumerable<string> answers)
        {
            _repository.AddQuestion(idQuestionare, text, isFewAnswers, answers);
            _repository.Commit();
        }

        /// <summary>
        /// Create new answer and add to selected question.  
        /// </summary>
        public void AddAnswerToQuestion(Guid questionnaireId, Guid questionId, string text)
        {
            _repository.AddAnswerToQuestion(questionnaireId, questionId, text);
            _repository.Commit();
        }

        /// <summary>
        /// Select all questionnaires from dataset and return list of questionnaireDto. 
        /// </summary>
        public IEnumerable<QuestionnaireDto> GetAll()
        {
            var entityesDto = new List<QuestionnaireDto>();
            foreach (var entity in _repository.FetchAll())
            {
                entityesDto.Add(entity.ToDto());
            }

            return entityesDto;
        }

        /// <summary>
        /// Find questionnaire by identifier and return questionnaireDto .
        /// </summary>
        public QuestionnaireDto FindById(Guid id)
        {
            return _repository.FindById(id).ToDto();
        }


        private IQuestionnaireRepository _repository;
    }
}
