using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Zedd.Dto;

namespace Zedd.Queries
{
  public interface IUserQuery
  {
    IList<UserInfo> GetUsers();
  }
}