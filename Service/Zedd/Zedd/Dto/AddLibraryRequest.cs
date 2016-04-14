using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddLibraryRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public string Name { get; set; }

    [DataMember]
    public string Address { get; set; }

    [DataMember]
    public string OpeningHours { get; set; }

    [DataMember]
    public string AdditionalInfo { get; set; }
  }
}