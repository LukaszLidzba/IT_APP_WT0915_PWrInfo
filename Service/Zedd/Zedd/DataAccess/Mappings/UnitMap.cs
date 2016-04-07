using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class UnitMap : ClassMap<Unit>
  {
    public UnitMap()
    {
      Table("Units");

      Id(x => x.Id);
      Map(x => x.Description);
      Map(x => x.Name);
      HasMany(x => x.Users);
    }
  }
}