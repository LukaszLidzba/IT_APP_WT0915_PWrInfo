using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public interface IUserQuery
  {
    IList<UserInfo> GetUsers();
  }

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
                        Unit = user.Unit,
                        Login = user.Login,
                        Surname = user.Surname,
                        IsAdmin = user.IsAdmin
                      }).ToList();
          }
        }
      }

      return result ?? new List<UserInfo>();
    }
  }
}