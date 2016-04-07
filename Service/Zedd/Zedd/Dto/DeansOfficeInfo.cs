using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class DeansOfficeInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public Department Department { get; set; }

    [DataMember]
    public string OpeningHours { get; set; }

    [DataMember]
    public string AdditionalInfo { get; set; }

    [DataMember]
    public string Address { get; set; }

    [DataMember]
    public string UserId { get; set; }
  }
}