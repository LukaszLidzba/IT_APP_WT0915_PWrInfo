using System;

namespace Zedd.DataAccess
{
  public class Events
  {
    public virtual int Id { get; set; }
    public virtual Departments Department { get; set; }
    public virtual string Title { get; set; }
    public virtual string Content { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual DateTime NotificationDate { get; set; }
    public virtual int UserId { get; set; }
  }
}