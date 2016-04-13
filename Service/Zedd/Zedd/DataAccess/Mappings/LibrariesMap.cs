using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zedd.DataAccess.Mappings
{
  public class LibrariesMap : ClassMap<Libraries>
  {
    public LibrariesMap()
    {
      Id(x => x.Id);
      Map(x => x.Name);
      Map(x => x.AdditionalInfo);
      Map(x => x.Address);
      Map(x => x.OpeningHours);
      Map(x => x.UserId).Not.Nullable();
    }
  }
}