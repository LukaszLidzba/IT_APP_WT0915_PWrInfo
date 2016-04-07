using NHibernate.Linq;
using System;
using System.Linq;
using Zedd.Commands;
using Zedd.DataAccess;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class LoginQueryDao : ILoginQueryDao
  {
    private readonly ISessionGenerator _sessionGenerator;

    public LoginQueryDao(ISessionGenerator sessionGenerator = null)
    {
      _sessionGenerator = sessionGenerator ?? new SessionGenerator();
    }

    public Guid Login(string loginName, string password)
    {
      Users authenticationUser;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          authenticationUser = session.Query<Users>().SingleOrDefault(x => x.Login == loginName.Trim() && x.Password == password.Trim());
        }
      }

      return authenticationUser != null ? _sessionGenerator.GenerateSession() : Guid.Empty;
    }
  }
}