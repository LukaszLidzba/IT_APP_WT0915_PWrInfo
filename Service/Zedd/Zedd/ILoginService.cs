using System;
using System.ServiceModel;

namespace Zedd
{
  [ServiceContract]
  public interface ILoginService
  {
    /// <summary>
    /// Method for login to system
    /// </summary>
    /// <param name="loginName">Users login</param>
    /// <param name="password">Users password</param>
    /// <returns>Ticket to authorize further actions</returns>
    [OperationContract]
    string Login(string loginName, string password);

    [OperationContract]
    void ProlongSession(Guid ticketId);
  }
}