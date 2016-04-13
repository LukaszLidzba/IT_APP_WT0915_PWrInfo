using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class TicketsMap : ClassMap<Tickets>
  {
    public TicketsMap()
    {
      Table("Tickets");

      Id(x => x.TicketId).GeneratedBy.Assigned();
      Map(x => x.Created).Not.Nullable();
    }
  }
}