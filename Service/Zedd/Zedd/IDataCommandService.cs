using System.ServiceModel;
using Zedd.Dto;

namespace Zedd
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataCommandService" in both code and config file together.
  [ServiceContract]
  public interface IDataCommandService
  {
    [OperationContract]
    void AddDeansOffice(AddDeansOfficeRequest request);

    [OperationContract]
    void AddLibrary(AddLibraryRequest request);

    [OperationContract]
    void AddMessage(AddMessageRequest request);

    [OperationContract]
    void AddEvent(AddEventRequest request);

    [OperationContract]
    void AddUnit(AddUnitRequest request);

    [OperationContract]
    void AddUser(AddUserRequest request);
  }
}