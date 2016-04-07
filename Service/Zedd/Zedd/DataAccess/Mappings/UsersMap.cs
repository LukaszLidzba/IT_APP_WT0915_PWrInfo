using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class UsersMap : ClassMap<Users>
  {
    public UsersMap()
    {
      Table("Users");

      Id(x => x.Id);
      Map(x => x.IsAdmin).Not.Nullable();
      Map(x => x.Name).Not.Nullable();
      Map(x => x.Surname).Not.Nullable();
      Map(x => x.Login).Not.Nullable();
      Map(x => x.Password).Not.Nullable().Column("Pass");
      References(x => x.Unit).Not.Nullable().Column("UnitId");
    }
  }
}