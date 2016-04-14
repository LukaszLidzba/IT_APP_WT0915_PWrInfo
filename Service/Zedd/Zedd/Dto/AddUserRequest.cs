using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddUserRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Surname { get; set; }

    [DataMember]
    public int UnitId { get; set; }

    [DataMember]
    public bool IsAdmin { get; set; }

    [DataMember]
    public string Login { get; set; }

    [DataMember]
    public string Password { get; set; }
  }
}