using System;

namespace Zedd.Commands
{
  public interface ISessionGenerator
  {
    Guid GenerateSession(int userId);

    void ProlongSession(Guid ticketId);
  }
}