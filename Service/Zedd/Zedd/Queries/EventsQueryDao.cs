using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class EventsQueryDao : IEventsQuery
  {
    public IList<EventInfo> GetEvents(int departmentId)
    {
      IList<EventInfo> result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var eventsList = session.Query<Events>().Where(events => events.Department.Id == departmentId).ToList();

          if (!eventsList.IsEmpty())
          {
            result = (from eventInfo in eventsList
                      where eventInfo != null
                      select new EventInfo()
                      {
                        Id = eventInfo.Id,
                        Department = new Department
                        {
                          Id = eventInfo.Department.Id,
                          Name = eventInfo.Department.Name
                        },
                        UserId = eventInfo.UserId,
                        Date = eventInfo.Date.ToString(CultureInfo.CurrentCulture),
                        Content = eventInfo.Content,
                        NotificationDate = eventInfo.NotificationDate.ToString(CultureInfo.CurrentCulture),
                        Title = eventInfo.Title
                      }).ToList();
          }
        }
      }

      return result ?? new List<EventInfo>();
    }
  }
}