using System.Runtime.Serialization;
using Zedd.DataAccess;

namespace Zedd.Dto
{
  [DataContract]
  public class MessageInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Content { get; set; }

    [DataMember]
    public Departments Department { get; set; }

    [DataMember]
    public bool Important { get; set; }

    [DataMember]
    public int UserId { get; set; }
  }
}