using System;

namespace Zedd.DataAccess
{
  public class Tickets
  {
    public virtual DateTime Created { get; set; }
    public virtual Guid TicketId { get; set; }
  }
}