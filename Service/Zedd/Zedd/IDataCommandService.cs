using System;
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

    [OperationContract]
    void DeleteUnits(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteDeansOffices(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteEvents(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteMessages(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteLibraries(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteUsers(DeleteRequest deleteRequest);

    [OperationContract]
    void DeleteDepartments(DeleteRequest deleteRequest);

    [OperationContract]
    void EditUnits(UnitInfo unitInfo, Guid ticketId);

    [OperationContract]
    void EditDeansOffices(DeansOfficeInfo deansOfficeInfo, Guid ticketId);

    [OperationContract]
    void EditEvents(EventInfo eventInfo, Guid ticketId);

    [OperationContract]
    void EditMessages(MessageInfo messageInfo, Guid ticketId);

    [OperationContract]
    void EditLibraries(LibraryInfo libraryInfo, Guid ticketId);

    [OperationContract]
    void EditUsers(UserInfo userInfo, Guid ticketId);

    [OperationContract]
    void EditDepartments(Department department, Guid ticketId);
  }
}