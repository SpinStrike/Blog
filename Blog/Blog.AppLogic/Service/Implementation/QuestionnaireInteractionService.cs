using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data.Repository;
using Blog.Data.EF;
using Blog.Data.Model;
using Blog.AppLogic.DTO;

namespace Blog.AppLogic.Service.Implementation
{
    /// <summary>
    /// Presents functionality for work with questionnaires as set of data.
    /// </summary>
    public class QuestionnaireInteractionService : BaseService, IQuestionnaireInteractionService
    {
        /// <summary>
        /// Create questionnaire interaction service. 
        /// </summary>
        public QuestionnaireInteractionService(IDbContextService dbContextService)
        {
            context = dbContextService.GetDbContextInstance();
            _qRepository = RepositoryFactory.GetQuestionnaireRepository(context);
            _cqRepository = RepositoryFactory.GetCompletedQuestionnaireRepository(context);
            _saRepository = RepositoryFactory.GetSelectedAnswerRepository(context);
        }

        /// <summary>
        /// Creates completed questionnaire from user answers.
        /// </summary>
        public void AddCompletedQuestionnaire(Guid questionnaireId, IEnumerable<Guid> answers)
        {
            var questionnaire = _qRepository.FindById(questionnaireId);
            var completedQuestionnaire = new CompletedQuestionnaire() { Questionnaire = questionnaire };

            foreach(var question in questionnaire.Questions)
            {
                foreach(var answer in question.Answers)
                {
                    if (answers.Contains(answer.Id))
                    {
                        completedQuestionnaire.SelectedAnswers.Add(new SelectedAnswer() { Question = question, Answer = answer });
                        ((ICollection<Guid>)answers).Remove(answer.Id);
                    }
                }
            }
            _cqRepository.Add(completedQuestionnaire);
            _cqRepository.Commit();
        }

        /// <summary>
        /// Collect and represent statistic for slected questionnaire quwstions.
        /// </summary>
        public QuestionnaireStatisticDto QuestionnaireStatistic(Guid questionnaireId)
        {
            var targetQuestionnaire = _qRepository.FindById(questionnaireId);

            var resultQuestionnaireStatistic = new QuestionnaireStatisticDto()
            {
                Id = targetQuestionnaire.Id,
                Title = targetQuestionnaire.Title
            };

            foreach(var question in targetQuestionnaire.Questions)
            {
                resultQuestionnaireStatistic.Questions.Add(new QuestionDto<CountedAnswerDto>()
                {
                    Id = question.Id,
                    IsFewAnswers =  question.IsFewAnswers,
                    Text = question.Text
                });

                foreach (var answer in question.Answers)
                {
                    resultQuestionnaireStatistic.Questions.Last().Answers.Add(new CountedAnswerDto() {
                        Id = answer.Id,
                        Text = answer.Text,
                        Count = _saRepository.FetchAll().Count(x => x.AnswerId.Equals(answer.Id))
                    });
                }
            }
            return resultQuestionnaireStatistic;
        }

        private IQuestionnaireRepository _qRepository;
        private ICompletedQuestionnaireRepository _cqRepository;
        private ISelectedAnswerRepository _saRepository;
    }
}
