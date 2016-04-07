using System.Collections.Generic;
using Zedd.Dto;
using Zedd.Queries;

namespace Zedd
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataQueryService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select DataQueryService.svc or DataQueryService.svc.cs at the Solution Explorer and start debugging.
  public class DataQueryService : IDataQueryService
  {
    private readonly IDeansOfficeQuery _deansOfficeQuery;

    public DataQueryService()
      : this(null)
    {
    }

    public DataQueryService(IDeansOfficeQuery deansOfficeQuery)
    {
      _deansOfficeQuery = deansOfficeQuery ?? new DeansOfficeQuery();
    }

    public DeansOfficeInfo GetDeansOfficeInfo(int id)
    {
      DeansOfficeInfo deansOfficeInfo = _deansOfficeQuery.GetDeansOfficeById(id);

      return deansOfficeInfo;
    }

    public IList<DeansOfficeInfo> GetAllDeansOffices()
    {
      IList<DeansOfficeInfo> deansOfficeInfo = _deansOfficeQuery.GetAllDeansOffices();

      return deansOfficeInfo;
    }
  }
}