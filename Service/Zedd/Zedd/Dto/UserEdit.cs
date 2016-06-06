using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class UserEdit
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Surname { get; set; }

    [DataMember]
    public UnitInfo Unit { get; set; }

    [DataMember]
    public bool IsAdmin { get; set; }
  }
}