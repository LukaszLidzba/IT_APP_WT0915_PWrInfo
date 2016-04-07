using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class Department
  {
    [DataMember]
    public int Id;

    [DataMember]
    public string Name;
  }
}