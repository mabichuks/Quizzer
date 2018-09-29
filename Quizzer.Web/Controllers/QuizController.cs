using Newtonsoft.Json;
using Quizzer.Domain.Entities;
using Quizzer.Domain.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Quizzer.Web.Controllers
{
    [RoutePrefix("api/quiz")]
    [Authorize]
    public class QuizController : ApiController
    {
        private readonly IQuestionRepository _questionRepo;

        private readonly ICategoryRepository _categoryRepo;

        private readonly IOptionRepository _optionRepo;

        public QuizController(IQuestionRepository qr, IOptionRepository or, ICategoryRepository cr)
        {
            _questionRepo = qr;
            _categoryRepo = cr;
            _optionRepo = or;
        }

        [HttpGet, Route("getquestions")]
        public HttpResponseMessage GetAllQuestions()
        {
            try
            {

                var result = _questionRepo.QuestionsandOptions();
                

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

        [HttpGet, Route("getcategories")]
        public HttpResponseMessage GetCategories()
        {
            try
            {
                var categories = _categoryRepo.GetAll();

                return this.Request.CreateResponse(HttpStatusCode.OK, categories);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                
            }
        }

        [HttpGet, Route("getcorrectanswer/{questionId}")]
        public HttpResponseMessage GetCorrectAnswerForQuestion(int questionId)
        {
            try
            {
                var answers = _optionRepo.GetAll();
                var correctAnswer = (from answer in answers
                         where answer.IsCorrectOption && answer.QuestionId == questionId
                         select answer).FirstOrDefault();

                return this.Request.CreateResponse(HttpStatusCode.Accepted, correctAnswer.Text);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);

            }
        }

         [HttpGet, Route("getquestionbycategory/{categoryId}")]
        public HttpResponseMessage GetQuestionByCategory(int categoryId)
        {
            try
            {
                var questions = _questionRepo.QuestionsandOptions();
                var questionbycategory = from question in questions
                                         where question.CategoryId == categoryId
                                         select question;

                return this.Request.CreateResponse(HttpStatusCode.OK, questionbycategory);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
