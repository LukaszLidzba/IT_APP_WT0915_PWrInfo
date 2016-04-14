using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddDeansOfficeRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public int DepartmentId { get; set; }

    [DataMember]
    public string OpeningHours { get; set; }

    [DataMember]
    public string AdditionalInfo { get; set; }

    [DataMember]
    public string Address { get; set; }
  }
}