using System;

namespace Zedd.Commands
{
  public interface ILoginHandler
  {
    Guid HandleLogin(string loginName, string password);

    bool HandleTryLogin(string loginName, string password);

    void HandleProlongSession(Guid ticketId);
  }
}