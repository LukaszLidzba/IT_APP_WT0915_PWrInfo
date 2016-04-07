using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class DeansOfficeQuery : IDeansOfficeQuery
  {
    public DeansOfficeInfo GetDeansOfficeById(int id)
    {
      DeansOfficeInfo result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var officeInfo = session.Query<DeansOffices>().FirstOrDefault(offices => offices.Id == id);

          if (officeInfo != null)
          {
            result = new DeansOfficeInfo
            {
              Id = officeInfo.Id,
              Department = new Department
              {
                Id = officeInfo.Department.Id,
                Name = officeInfo.Department.Name
              },
              Address = officeInfo.Address,
              UserId = officeInfo.UserId,
              AdditionalInfo = officeInfo.AdditionalInfo,
              OpeningHours = officeInfo.OpeningHours
            };
          }
        }
      }

      return result ?? new DeansOfficeInfo();
    }

    public IList<DeansOfficeInfo> GetAllDeansOffices()
    {
      List<DeansOfficeInfo> deansOfficeInfos;

      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var offices = session.Query<DeansOffices>().ToList();

          deansOfficeInfos = (from office in offices
                              where office != null
                              select new DeansOfficeInfo
                              {
                                Id = office.Id,
                                Department = new Department
                                {
                                  Id = office.Department.Id,
                                  Name = office.Department.Name
                                },
                                Address = office.Address,
                                UserId = office.UserId,
                                AdditionalInfo = office.AdditionalInfo,
                                OpeningHours = office.OpeningHours
                              }).ToList();
        }
      }
      return deansOfficeInfos;
    }
  }
}