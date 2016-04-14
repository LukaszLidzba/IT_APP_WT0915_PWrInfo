using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddMessageRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Content { get; set; }

    [DataMember]
    public int DepartmentId { get; set; }

    [DataMember]
    public bool Important { get; set; }
  }
}