using System.Collections.Generic;

namespace Zedd.DataAccess
{
  public class Departments
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual IList<DeansOffices> DeansOffices { get; set; }
  }
}