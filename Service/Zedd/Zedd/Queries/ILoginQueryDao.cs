using System;

namespace Zedd.Queries
{
  public interface ILoginQueryDao
  {
    Guid Login(string loginName, string password);
  }
}