using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;
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

    public void ProlongSession(Guid ticketId)
    {
      using (var session = NHibernateHelper.OpenSession())
      {
        using (var transaction = session.BeginTransaction())
        {
          var ticket = session.Query<Tickets>().SingleOrDefault(tickets => tickets.TicketId == ticketId && tickets.Created > DateTime.Now.AddMinutes(-20));

          if (ticket != null)
          {
            ticket.Created = DateTime.Now;
            session.Update(ticket);
            transaction.Commit();

            return;
          }

          throw new Exception("Active ticket not found");
        }
      }
    }
  }
}