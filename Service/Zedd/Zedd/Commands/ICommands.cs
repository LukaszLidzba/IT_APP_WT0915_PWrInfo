using Zedd.Dto;

namespace Zedd.Commands
{
  public interface ICommands
  {
    void AddDeansOffice(AddDeansOfficeRequest request);

    void AddLibrary(AddLibraryRequest request);

    void AddMessage(AddMessageRequest request);

    void AddEvent(AddEventRequest request);

    void AddUnit(AddUnitRequest request);

    void AddUser(AddUserRequest request);

    void Delete<T>(int id);

    void Edit(UserEdit userInfo);

    void Edit(UserInfo userInfo);

    void Edit(LibraryInfo libraryInfo);

    void Edit(EventInfo eventInfo);

    void Edit(Department departmentInfo);

    void Edit(DeansOfficeInfo deansOfficeInfo);

    void Edit(UnitInfo unitInfo);

    void Edit(MessageInfo messageInfo);

    void ChangePassword(int id, string newPassword, string oldPassword);
  }
}