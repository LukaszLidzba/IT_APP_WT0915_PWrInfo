using System;
using Zedd.Exceptions;
using Zedd.Queries;

namespace Zedd.Commands
{
  public class LoginHandler : ILoginHandler
  {
    private readonly ILoginQueryDao _loginQueryDao;

    public LoginHandler()
    {
      _loginQueryDao = new LoginQueryDao();
    }

    public LoginHandler(ILoginQueryDao loginQueryDao)
    {
      _loginQueryDao = loginQueryDao;
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
  }
}