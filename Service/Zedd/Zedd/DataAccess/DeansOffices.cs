using Zedd.Dto;

namespace Zedd.DataAccess
{
  public class DeansOffices
  {
    public virtual int Id { get; set; }

    public virtual Departments Department { get; set; }

    public virtual string OpeningHours { get; set; }

    public virtual string AdditionalInfo { get; set; }

    public virtual string Address { get; set; }

    public virtual string UserId { get; set; }
  }
}