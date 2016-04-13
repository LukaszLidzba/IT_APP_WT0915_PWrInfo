using System.Runtime.Serialization;
using Zedd.DataAccess;

namespace Zedd.Dto
{
  [DataContract]
  public class UserInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Surname { get; set; }

    [DataMember]
    public Unit Unit { get; set; }

    [DataMember]
    public int IsAdmin { get; set; }

    [DataMember]
    public string Login { get; set; }

    [DataMember]
    public string Password { get; set; }
  }
}