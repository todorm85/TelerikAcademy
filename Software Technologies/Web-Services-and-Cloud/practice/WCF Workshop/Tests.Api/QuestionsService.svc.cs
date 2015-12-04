using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tests.Models;

namespace Tests.Api
{
    public class QuestionsService : IQuestionsService
    {
        static IList<Question> questions = new List<Question>();

        public Question AddQuestion(Question question)
        {
            questions.Add(question);
            return question;
        }

        public IQueryable<Question> GetAll()
        {
            SetCorrectContentType();

            return questions.AsQueryable();
        }

        private static void SetCorrectContentType()
        {
            var webOperationContent = WebOperationContext.Current;
            if (webOperationContent.IncomingRequest.ContentType != null
                && webOperationContent.IncomingRequest.ContentType.Contains("application/json"))
            {
                WebOperationContext.Current.OutgoingResponse.Format = WebMessageFormat.Json;
            }
        }

        public Question GetById(string id)
        {
            return questions.First();
        }
    }
}
