using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Zedd.Dto;
using Zedd.Queries;

namespace Zedd
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RestDataService" in code, svc and config file together.
  // NOTE: In order to launch WCF Test Client for testing this service, please select RestDataService.svc or RestDataService.svc.cs at the Solution Explorer and start debugging.
  public class RestDataService : IRestDataService
  {
    private readonly IDeansOfficeQuery _deansOfficeQuery;
    private readonly IEventsQuery _eventsQuery;
    private readonly IMessageQuery _messageQuery;
    private readonly ILibraryQuery _libraryQuery;
    private readonly IUnitQuery _unitQuery;

    public RestDataService()
      : this(null, null, null, null, null)
    {
    }

    public RestDataService(IDeansOfficeQuery deansOfficeQuery, IEventsQuery eventsQuery, IMessageQuery messageQuery, ILibraryQuery libraryQuery, IUnitQuery unitQuery)
    {
      _deansOfficeQuery = deansOfficeQuery ?? new DeansOfficeQuery();
      _eventsQuery = eventsQuery ?? new EventsQueryDao();
      _messageQuery = messageQuery ?? new MessageQueryDao();
      _libraryQuery = libraryQuery ?? new LibraryQueryDao();
      _unitQuery = unitQuery ?? new UnitQueryDao();
    }

    public IList<DeansOfficeInfo> GetDeansOffices()
    {
      IList<DeansOfficeInfo> deansOffices = _deansOfficeQuery.GetAllDeansOffices();

      return deansOffices;
    }

    public DeansOfficeInfo GetDeansOfficeInfo(string deansOfficeId)
    {
      int id = int.Parse(deansOfficeId.Trim());
      DeansOfficeInfo deansOfficeInfo = _deansOfficeQuery.GetDeansOfficeById(id);

      return deansOfficeInfo;
    }

    public IList<LibraryInfo> GetLibraries()
    {
      var libraries = _libraryQuery.GetLibraries();

      return libraries;
    }

    public IList<MessageInfo> GetMessages(string departmentId)
    {
      int id = int.Parse(departmentId.Trim());

      var messages = _messageQuery.GetMessages(id).OrderByDescending(info => info.Id).ToList();

      return messages;
    }

    public IList<EventInfo> GetEvents(string departmentId)
    {
      int id = int.Parse(departmentId.Trim());

      var events = _eventsQuery.GetEvents(id).OrderByDescending(info => info.Id).ToList();

      return events;
    }

    public IList<UnitInfo> GetUnits()
    {
      var units = _unitQuery.GetUnits();

      return units;
    }
  }
}