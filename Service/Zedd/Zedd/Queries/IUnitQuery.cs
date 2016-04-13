using System.Collections.Generic;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface IUnitQuery
  {
    IList<UnitInfo> GetUnits();
  }
}