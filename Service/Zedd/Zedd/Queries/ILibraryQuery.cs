using System.Collections.Generic;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface ILibraryQuery
  {
    IList<LibraryInfo> GetLibraries();
  }
}