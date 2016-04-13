using System.Collections.Generic;
using System.Runtime.Serialization;
using Zedd.DataAccess;

namespace Zedd.Dto
{
  [DataContract]
  public class UnitInfo
  {
    [DataMember]
    public int Id { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public string Name { get; set; }
  }
}