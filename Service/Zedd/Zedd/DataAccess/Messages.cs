namespace Zedd.DataAccess
{
  public class Messages
  {
    public virtual int Id { get; set; }
    public virtual string Title { get; set; }
    public virtual string Content { get; set; }
    public virtual Departments Department { get; set; }
    public virtual bool Important { get; set; }
    public virtual int UserId { get; set; }
  }
}