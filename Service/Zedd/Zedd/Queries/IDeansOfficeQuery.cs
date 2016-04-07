using System.Collections.Generic;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface IDeansOfficeQuery
  {
    DeansOfficeInfo GetDeansOfficeById(int id);

    IList<DeansOfficeInfo> GetAllDeansOffices();
  }
}