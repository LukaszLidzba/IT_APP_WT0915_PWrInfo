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

    [OperationContract]
    IList<LibraryInfo> GetLibraries(Guid ticket);

    [OperationContract]
    IList<MessageInfo> GetMessages(Guid ticket);

    [OperationContract]
    IList<EventInfo> GetEvents(Guid ticket);

    [OperationContract]
    IList<UnitInfo> GetUnits(Guid ticket);

    [OperationContract]
    IList<UserInfo> GetUsers(Guid ticket);
  }
}