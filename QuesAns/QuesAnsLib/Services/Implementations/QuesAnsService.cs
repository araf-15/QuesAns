using NHbDataAccessLayer.Entities;
using QuesAnsLib.BusinessObjects;
using QuesAnsLib.Services.IServices;
using QuesAnsLib.UnitOfWorks.IUnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO = QuesAnsLib.BusinessObjects;

namespace QuesAnsLib.Services.Implementations
{
    public class QuesAnsService : IQuesAnsService
    {
        private readonly IQuesAnsUnitOfWork _quesAnsUnitOfWork;

        public QuesAnsService(IQuesAnsUnitOfWork quesAnsUnitOfWork)
        {
            _quesAnsUnitOfWork = quesAnsUnitOfWork;
        }

        #region QuesAns Services
        public async Task<object> AddUser(UserBO model)
        {
            return await _quesAnsUnitOfWork.QuesAnsRepository.Add(new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                UserType = model.UserType,
                PasswordHash = model.PasswordHash,
                InstituteName = model.InstituteName,
                InstituteId = model.InstituteId,
                Email = model.Email

            });
        }

        public UserBO GetUser(Guid Id)
        {
            var user = _quesAnsUnitOfWork.QuesAnsRepository.GetById(Id);
            return BO.UserBO.ConvertToSelf(user);
        }

        public User GetUserEO(Guid id)
        {
            var user = _quesAnsUnitOfWork.QuesAnsRepository.GetById(id);
            return user;
        }

        public Question GetQuestion(Guid questionId)
        {
            var question = _quesAnsUnitOfWork.QuestionRepository.GetById(questionId);
            return question;
        }

        public List<User> GetUserList()
        {
            var userList = _quesAnsUnitOfWork.QuesAnsRepository.GetAll().ToList();
            return userList;
        }

        public void UpdateUser(UserBO userBO)
        {
            var userEntity = _quesAnsUnitOfWork.QuesAnsRepository.GetById(userBO.Id);

            if(userEntity != null)
            {
                userEntity.FirstName = userBO.FirstName;
                userEntity.LastName = userBO.LastName;
            }

            _quesAnsUnitOfWork.QuesAnsRepository.Update(userEntity);
        }

        public void DeleteUser(Guid id)
        {
            var userEntity = _quesAnsUnitOfWork.QuesAnsRepository.GetById(id);

            _quesAnsUnitOfWork.QuesAnsRepository.Delete(userEntity);
        }

        public UserBO IsLoggedIn(string userName, string password)
        {
            var user = _quesAnsUnitOfWork.QuesAnsRepository.IsLoggedIn(userName, password);
            if(user != null)
            {
                return BO.UserBO.ConvertToSelf(user);
            }
            return null;
        }
        #endregion

        #region Question Services
        public async Task<object> AddQuestion(QuestionBO model)
        {
            return await _quesAnsUnitOfWork.QuestionRepository.Add(new Question
            {
                Id = model.Id,
                QuesTitle = model.QuesTitle,
                QuesDescription = model.QuesDescription,
                QuesTime = model.QuesTime,
                QuesById = model.QuesById
            });
        }

        public List<Question> GetQuestionList()
        {
            var questionList = _quesAnsUnitOfWork.QuestionRepository.GetTestQuestions();
            return questionList;
        }

        public List<Answer> GetAnswers(Guid questionId)
        {
            var answerList = _quesAnsUnitOfWork.AnswerRepository.GetAnswersByQuestionId(questionId);
            return answerList;
        }

        public async Task<object> AddAnswer(AnswerBO model)
        {
            return await _quesAnsUnitOfWork.AnswerRepository.Add(new Answer
            {
                Id = model.Id,
                AnswerById = model.AnsweById,
                AnswerDescription = model.AnswerDescription,
                AnswerTime = model.AsnwerTime,
                QuestionId = model.QuestionId
            });
        }



        #endregion
    }
}
