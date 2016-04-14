using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddUnitRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public string Name { get; set; }
  }
}