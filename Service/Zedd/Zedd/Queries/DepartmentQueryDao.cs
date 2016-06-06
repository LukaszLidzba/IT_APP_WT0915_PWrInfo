using NHibernate.Linq;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class DepartmentQueryDao : IDepartmentQuery
  {
    public Department GetById(int id)
    {
      Department result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var departemntInfo = session.Query<Departments>().FirstOrDefault(departments => departments.Id == id);

          if (departemntInfo != null)
          {
            result = new Department
            {
              Id = departemntInfo.Id,
              Name = departemntInfo.Name
            };
          }
        }
      }

      return result ?? new Department();
    }
  }
}