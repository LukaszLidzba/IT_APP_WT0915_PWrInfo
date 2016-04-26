using NHibernate.Linq;
using System;
using System.Linq;
using System.Security;
using Zedd.Commands;
using Zedd.DataAccess;
using Zedd.Dto;
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

      return authenticationUser != null ? _sessionGenerator.GenerateSession(authenticationUser.Id) : Guid.Empty;
    }

    public void IsAuthenticated(Guid ticket)
    {
      Tickets record;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          record = session.Query<Tickets>().SingleOrDefault(x => x.TicketId == ticket && x.Created < DateTime.Now.AddMinutes(20));
        }
      }

      if (record == null)
      {
        throw new SecurityException("Active ticket not found!");
      }
    }

    public UserInfo GetUser(Guid ticket)
    {
      UserInfo userInfo;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var userId = session.Query<Tickets>().SingleOrDefault(x => x.TicketId == ticket && x.Created < DateTime.Now.AddMinutes(20));

          var record = session.Query<Users>().SingleOrDefault(x => x.Id == userId.UserId);

          userInfo = new UserInfo
          {
            Id = record.Id,
            Name = record.Name,
            Unit = new UnitInfo
            {
              Id = record.Unit.Id,
              Name = record.Unit.Name,
              Description = record.Unit.Description
            },
            IsAdmin = record.IsAdmin,
            Login = record.Login,
            Surname = record.Surname
          };
        }
      }

      if (userInfo == null)
      {
        throw new SecurityException("Active ticket not found!");
      }

      return userInfo;
    }
  }
}