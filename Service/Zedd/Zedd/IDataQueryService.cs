using System;
using System.Collections.Generic;
using System.ServiceModel;
using Zedd.Dto;

namespace Zedd
{
  [ServiceContract]
  public interface IDataQueryService
  {
    [OperationContract]
    DeansOfficeInfo GetDeansOfficeInfo(int id, Guid ticket);

    [OperationContract]
    IList<DeansOfficeInfo> GetAllDeansOffices(Guid ticket);
  }
}