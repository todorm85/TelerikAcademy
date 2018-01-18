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
    [ServiceContract]
    public interface IQuestionsService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/questions")]
        IQueryable<Question> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/questions/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        Question GetById(string id);

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "/questions",
            ResponseFormat = WebMessageFormat.Json)]
        Question AddQuestion(Question question);
    }
}
