using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security;
using System.ServiceModel;
using Zedd.Commands;
using Zedd.Dto;
using Zedd.Queries;

namespace Zedd
{
  public class DataQueryService : IDataQueryService
  {
    private readonly IDeansOfficeQuery _deansOfficeQuery;
    private readonly ILoginQueryDao _loginQuery;
    private readonly ISessionGenerator _sessionGenerator;
    private readonly IEventsQuery _eventsQuery;
    private readonly IMessageQuery _messageQuery;
    private readonly ILibraryQuery _libraryQuery;
    private readonly IUnitQuery _unitQuery;
    private readonly IUserQuery _userQuery;

    public DataQueryService()
      : this(null, null, null, null, null, null, null, null)
    {
    }

    public DataQueryService(IDeansOfficeQuery deansOfficeQuery, ILoginQueryDao loginQuery, ISessionGenerator sessionGenerator, IEventsQuery eventsQuery, IMessageQuery messageQuery, ILibraryQuery libraryQuery, IUnitQuery unitQuery, IUserQuery userQuery)
    {
      _deansOfficeQuery = deansOfficeQuery ?? new DeansOfficeQuery();
      _loginQuery = loginQuery ?? new LoginQueryDao();
      _sessionGenerator = sessionGenerator ?? new SessionGenerator();
      _eventsQuery = eventsQuery ?? new EventsQueryDao();
      _messageQuery = messageQuery ?? new MessageQueryDao();
      _libraryQuery = libraryQuery ?? new LibraryQueryDao();
      _unitQuery = unitQuery ?? new UnitQueryDao();
      _userQuery = userQuery ?? new UserQueryDao();
    }

    public DeansOfficeInfo GetDeansOfficeInfo(int id, Guid ticket)
    {
      DeansOfficeInfo deansOfficeInfo;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        deansOfficeInfo = _deansOfficeQuery.GetDeansOfficeById(id);
      }
      catch (SecurityException e)
      {
        throw new FaultException(e.Message);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }

      return deansOfficeInfo;
    }

    public IList<DeansOfficeInfo> GetAllDeansOffices(Guid ticket)
    {
      IList<DeansOfficeInfo> deansOfficeInfo;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        deansOfficeInfo = _deansOfficeQuery.GetAllDeansOffices();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }

      return deansOfficeInfo;
    }

    public IList<LibraryInfo> GetLibraries(Guid ticket)
    {
      IList<LibraryInfo> libraries;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        libraries = _libraryQuery.GetLibraries();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
      return libraries;
    }

    public IList<MessageInfo> GetMessages(Guid ticket, DateTime? startDate = null)
    {
      IList<MessageInfo> messages;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        messages = _messageQuery.GetAllMessages();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
      return messages;
    }

    public IList<EventInfo> GetEvents(Guid ticket, DateTime? startDate = null, DateTime? endDate = null)
    {
      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        var events = _eventsQuery.GetAllEvents();

        if (startDate == null || endDate == null)
        {
          return events.Where(info => DateTime.Parse(info.Date) > DateTime.Now.AddDays(-30)).ToList();
        }

        return events.Where(info => DateTime.Parse(info.Date) >= startDate && DateTime.Parse(info.Date) <= endDate).ToList();
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

    public IList<UnitInfo> GetUnits(Guid ticket)
    {
      IList<UnitInfo> units;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        units = _unitQuery.GetUnits();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }

      return units;
    }

    public IList<UserInfo> GetUsers(Guid ticket)
    {
      IList<UserInfo> users;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        users = _userQuery.GetUsers();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }
      return users;
    }
  }
}