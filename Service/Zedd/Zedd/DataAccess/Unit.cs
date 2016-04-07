using System.Collections.Generic;

namespace Zedd.DataAccess
{
  public class Unit
  {
    public virtual int Id { get; set; }
    public virtual string Description { get; set; }
    public virtual string Name { get; set; }
    public virtual IList<Users> Users { get; set; }
  }
}