using System.Collections.Generic;
using System.ServiceModel;
using Zedd.Dto;

namespace Zedd
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataQueryService" in both code and config file together.
  [ServiceContract]
  public interface IDataQueryService
  {
    [OperationContract]
    DeansOfficeInfo GetDeansOfficeInfo(int id);

    [OperationContract]
    IList<DeansOfficeInfo> GetAllDeansOffices();
  }
}