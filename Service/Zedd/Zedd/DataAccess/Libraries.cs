namespace Zedd.DataAccess
{
  public class Libraries
  {
    public virtual int Id { get; set; }
    public virtual string Name { get; set; }
    public virtual string Address { get; set; }
    public virtual string OpeningHours { get; set; }
    public virtual string AdditionalInfo { get; set; }
    public virtual int UserId { get; set; }
  }
}