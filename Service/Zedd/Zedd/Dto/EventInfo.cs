using System;
using System.Runtime.Serialization;

namespace Zedd.Dto
{
  [DataContract]
  public class EventInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public Department Department { get; set; }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Content { get; set; }

    [DataMember]
    public string Date { get; set; }

    [DataMember]
    public string NotificationDate { get; set; }

    [DataMember]
    public int UserId { get; set; }
  }
}