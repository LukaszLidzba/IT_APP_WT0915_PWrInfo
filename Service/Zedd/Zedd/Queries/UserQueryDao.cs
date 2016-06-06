using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class UserQueryDao : IUserQuery
  {
    public IList<UserInfo> GetUsers()
    {
      IList<UserInfo> result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var users = session.Query<Users>().ToList();

          if (!users.IsEmpty())
          {
            result = (from user in users
                      where user != null
                      select new UserInfo()
                      {
                        Id = user.Id,
                        Name = user.Name,
                        Unit = new UnitInfo
                        {
                          Id = user.Unit.Id,
                          Name = user.Unit.Name,
                          Description = user.Unit.Description
                        },
                        Login = user.Login,
                        Surname = user.Surname,
                        IsAdmin = user.IsAdmin
                      }).ToList();
          }
        }
      }

      return result ?? new List<UserInfo>();
    }

    public UserInfo GetById(int id)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var user = session.Query<Users>().SingleOrDefault(users => users.Id == id);

          if (user != null)
          {
            return new UserInfo()
            {
              Id = user.Id,
              Name = user.Name,
              Unit = new UnitInfo
              {
                Id = user.Unit.Id,
                Name = user.Unit.Name,
                Description = user.Unit.Description
              },
              Login = user.Login,
              Surname = user.Surname,
              IsAdmin = user.IsAdmin
            };
          }
        }
      }

      return new UserInfo();
    }
  }
}