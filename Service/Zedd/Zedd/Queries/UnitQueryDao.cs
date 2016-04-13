using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class UnitQueryDao : IUnitQuery
  {
    public IList<UnitInfo> GetUnits()
    {
      IList<UnitInfo> result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var messages = session.Query<Unit>().ToList();

          if (!messages.IsEmpty())
          {
            result = (from message in messages
                      where message != null
                      select new UnitInfo
                      {
                        Id = message.Id,
                        Name = message.Name,
                        Description = message.Description
                      }).ToList();
          }
        }
      }

      return result ?? new List<UnitInfo>();
    }
  }
}