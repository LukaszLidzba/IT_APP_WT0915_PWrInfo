using System.Collections.Generic;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface IEventsQuery
  {
    IList<EventInfo> GetEvents(int departmentId);

    IList<EventInfo> GetAllEvents();

    EventInfo GetById(int id);
  }
}