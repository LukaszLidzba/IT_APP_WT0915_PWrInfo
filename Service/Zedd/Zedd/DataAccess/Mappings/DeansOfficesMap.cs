using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class DeansOfficesMap : ClassMap<DeansOffices>
  {
    public DeansOfficesMap()
    {
      Table("DeansOffices");

      Id(x => x.Id);
      Map(x => x.AdditionalInfo);
      Map(x => x.Address);
      Map(x => x.OpeningHours);
      Map(x => x.UserId).Not.Nullable();
      References(x => x.Department).Column("DepartmentId");
    }
  }
}