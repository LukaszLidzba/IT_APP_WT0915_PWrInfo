using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class EventsMap : ClassMap<Events>
  {
    public EventsMap()
    {
      Id(x => x.Id);
      Map(x => x.Title).Not.Nullable();
      Map(x => x.Content);
      Map(x => x.Date).Not.Nullable();
      Map(x => x.NotificationDate);
      Map(x => x.UserId).Not.Nullable();
      References(x => x.Department).Column("DepartmentId");
    }
  }
}