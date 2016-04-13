using FluentNHibernate.Conventions;
using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;
using Zedd.DataAccess;
using Zedd.Dto;
using Zedd.NHibernate;

namespace Zedd.Queries
{
  public class MessageQueryDao : IMessageQuery
  {
    public IList<MessageInfo> GetMessages(int departmentId)
    {
      IList<MessageInfo> result = null;
      using (var session = NHibernateHelper.OpenSession())
      {
        using (session.BeginTransaction())
        {
          var messages = session.Query<Messages>().Where(x => x.Department.Id == departmentId).ToList();

          if (!messages.IsEmpty())
          {
            result = (from message in messages
                      where message != null
                      select new MessageInfo
                      {
                        Id = message.Id,
                        UserId = message.UserId,
                        Content = message.Content,
                        Department = new Departments
                        {
                          Name = message.Department.Name,
                          Id = message.Department.Id
                        },
                        Title = message.Title,
                        Important = message.Important
                      }).ToList();
          }
        }
      }

      return result ?? new List<MessageInfo>();
    }
  }
}