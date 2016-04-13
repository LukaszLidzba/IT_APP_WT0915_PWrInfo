using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface IEventsQuery
  {
    IList<EventInfo> GetEvents(int departmentId);
  }
}