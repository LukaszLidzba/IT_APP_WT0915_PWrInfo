using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class MessagesMap : ClassMap<Messages>
  {
    public MessagesMap()
    {
      Id(x => x.Id);
      Map(x => x.Title);
      Map(x => x.Content);
      Map(x => x.Important);
      Map(x => x.UserId);
      References(x => x.Department).Column("DepartmentId");
    }
  }
}