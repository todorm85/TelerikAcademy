namespace Teleimot.Server.Wcf
{
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using Models.User;

    [ServiceContract]
    public interface IWcfUsersService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "/users/top.svc",
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<object> GetTopUsers();
    }
}