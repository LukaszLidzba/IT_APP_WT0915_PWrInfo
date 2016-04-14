namespace Zedd.DataAccess
{
  public class Users
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Surname { get; set; }
    public virtual Unit Unit { get; set; }
    public virtual bool IsAdmin { get; set; }
    public virtual string Login { get; set; }
    public virtual string Password { get; set; }
  }
}