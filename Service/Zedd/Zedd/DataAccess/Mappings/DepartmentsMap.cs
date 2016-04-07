using FluentNHibernate.Mapping;

namespace Zedd.DataAccess.Mappings
{
  public class DepartmentsMap : ClassMap<Departments>
  {
    public DepartmentsMap()
    {
      Table("Departments");

      Id(x => x.Id);
      Map(x => x.Name).Not.Nullable();
      HasMany(x => x.DeansOffices);
    }
  }
}