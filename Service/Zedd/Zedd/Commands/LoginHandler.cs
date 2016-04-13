using System;
using Zedd.Exceptions;
using Zedd.Queries;

namespace Zedd.Commands
{
  public class LoginHandler : ILoginHandler
  {
    private readonly ILoginQueryDao _loginQueryDao;
    private readonly ISessionGenerator _sessionGenerator;

    public LoginHandler()
    {
      _loginQueryDao = new LoginQueryDao();
      _sessionGenerator = new SessionGenerator();
    }

    public LoginHandler(ILoginQueryDao loginQueryDao, ISessionGenerator sessionGenerator)
    {
      _loginQueryDao = loginQueryDao;
      _sessionGenerator = sessionGenerator;
    }

    public Guid HandleLogin(string loginName, string password)
    {
      Guid result = _loginQueryDao.Login(loginName, password);

      if (result == Guid.Empty)
      {
        throw new WrongPasswordException();
      }

      return result;
    }

    public void HandleProlongSession(Guid ticketId)
    {
      _sessionGenerator.ProlongSession(ticketId);
    }
  }
}