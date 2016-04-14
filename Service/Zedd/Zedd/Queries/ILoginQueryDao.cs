using System;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface ILoginQueryDao
  {
    Guid Login(string loginName, string password);

    void IsAuthenticated(Guid ticket);

    UserInfo GetUser(Guid ticket);
  }
}