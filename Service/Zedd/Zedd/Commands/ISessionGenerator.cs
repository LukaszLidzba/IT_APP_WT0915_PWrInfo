using System;

namespace Zedd.Commands
{
  public interface ISessionGenerator
  {
    Guid GenerateSession();
  }
}