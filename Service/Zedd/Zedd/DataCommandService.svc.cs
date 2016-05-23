using System;
using System.Security;
using System.ServiceModel;
using Zedd.Commands;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.Queries;

namespace Zedd
{
  public class DataCommandService : IDataCommandService
  {
    private readonly ICommands _commands;
    private readonly ILoginQueryDao _loginQuery;
    private readonly ISessionGenerator _sessionGenerator;

    public DataCommandService()
      : this(null, null, null)
    {
    }

    public DataCommandService(ICommands commands, ILoginQueryDao loginQuery, ISessionGenerator sessionGenerator)
    {
      _commands = commands ?? new Commands.Commands();
      _loginQuery = loginQuery ?? new LoginQueryDao();
      _sessionGenerator = sessionGenerator ?? new SessionGenerator();
    }

    public void AddDeansOffice(AddDeansOfficeRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddDeansOffice(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void AddLibrary(AddLibraryRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddLibrary(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void AddMessage(AddMessageRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddMessage(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void AddEvent(AddEventRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddEvent(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void AddUnit(AddUnitRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddUnit(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void AddUser(AddUserRequest request)
    {
      try
      {
        _loginQuery.IsAuthenticated(request.Ticket);
        _sessionGenerator.ProlongSession(request.Ticket);

        _commands.AddUser(request);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteUnits(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Unit>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteDeansOffices(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<DeansOffices>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteEvents(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Events>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteMessages(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Messages>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteLibraries(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Libraries>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteUsers(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Users>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void DeleteDepartments(DeleteRequest deleteRequest)
    {
      try
      {
        _loginQuery.IsAuthenticated(deleteRequest.Ticket);

        _commands.Delete<Departments>(deleteRequest.Id);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditUnits(UnitInfo unitInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(unitInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditDeansOffices(DeansOfficeInfo deansOfficeInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(deansOfficeInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditEvents(EventInfo eventInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(eventInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditMessages(MessageInfo messageInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(messageInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditLibraries(LibraryInfo libraryInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(libraryInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditUsers(UserInfo userInfo, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(userInfo);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }

    public void EditDepartments(Department department, Guid ticketId)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticketId);

        _commands.Edit(department);
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
    }
  }
}