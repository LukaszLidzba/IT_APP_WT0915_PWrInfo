using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class ChangePasswordRequest
  {
    [DataMember]
    public Guid TicketId { get; set; }

    [DataMember]
    public string NewPassword { get; set; }

    [DataMember]
    public string OldPassword { get; set; }
  }
}