using System;
using Zedd.DataAccess;
using Zedd.NHibernate;

namespace Zedd.Commands
{
  public class SessionGenerator : ISessionGenerator
  {
    public Guid GenerateSession()
    {
      var newTicket = Guid.NewGuid();

      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var tickets = new Tickets
          {
            TicketId = newTicket,
            Created = DateTime.Now
          };

          session.Save(tickets);
          transaction.Commit();
        }
      }

      return newTicket;
    }
  }
}