using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class LibraryQueryDao : ILibraryQuery
  {
    public IList<LibraryInfo> GetLibraries()
    {
      IList<LibraryInfo> result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var libraries = session.Query<Libraries>().ToList();

          if (!libraries.IsEmpty())
          {
            result = (from library in libraries
                      where library != null
                      select new LibraryInfo
                      {
                        Id = library.Id,
                        UserId = library.UserId,
                        Address = library.Address,
                        OpeningHours = library.OpeningHours,
                        AdditionalInfo = library.AdditionalInfo,
                        Name = library.Name
                      }).ToList();
          }
        }
      }

      return result ?? new List<LibraryInfo>();
    }

    public LibraryInfo GetById(int id)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var library = session.Query<Libraries>().SingleOrDefault(libraries => libraries.Id == id);

          if (library != null)
          {
            return new LibraryInfo
            {
              Id = library.Id,
              UserId = library.UserId,
              Address = library.Address,
              OpeningHours = library.OpeningHours,
              AdditionalInfo = library.AdditionalInfo,
              Name = library.Name
            };
          }
        }
      }

      return new LibraryInfo();
    }
  }
}