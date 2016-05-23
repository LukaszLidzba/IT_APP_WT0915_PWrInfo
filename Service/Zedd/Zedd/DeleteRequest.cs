using System;
using System.Runtime.Serialization;

namespace Zedd
{
  [DataContract]
  public class DeleteRequest
  {
    [DataMember(IsRequired = true)]
    public Guid Ticket { get; set; }

    [DataMember(IsRequired = true)]
    public int Id { get; set; }
  }
}