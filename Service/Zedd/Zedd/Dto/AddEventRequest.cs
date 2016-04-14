using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class AddEventRequest
  {
    [DataMember]
    public Guid Ticket { get; set; }

    [DataMember]
    public int DepartmentId { get; set; }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Content { get; set; }

    [DataMember]
    public DateTime Date { get; set; }

    [DataMember]
    public DateTime NotificationDate { get; set; }
  }
}