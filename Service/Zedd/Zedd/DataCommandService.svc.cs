using System;
using System.Security;
using System.ServiceModel;
using Zedd.Commands;
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
  }
}