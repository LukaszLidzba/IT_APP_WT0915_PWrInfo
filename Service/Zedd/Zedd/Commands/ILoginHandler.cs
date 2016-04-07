using System;

namespace Zedd.Commands
{
  public interface ILoginHandler
  {
    Guid HandleLogin(string loginName, string password);
  }
}