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
  }
}