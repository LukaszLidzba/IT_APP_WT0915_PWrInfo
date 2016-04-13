using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class LibraryInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Address { get; set; }

    [DataMember]
    public string OpeningHours { get; set; }

    [DataMember]
    public string AdditionalInfo { get; set; }

    [DataMember]
    public int UserId { get; set; }
  }
}