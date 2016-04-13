using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Zedd.Dto;

namespace Zedd
{
  [ServiceContract(Name = "restDataService")]
  public interface IRestDataService
  {
    [OperationContract]
    [WebGet(UriTemplate = "deansOffices", ResponseFormat = WebMessageFormat.Json)]
    IList<DeansOfficeInfo> GetDeansOffices();

    [OperationContract]
    [WebGet(UriTemplate = "deansOffice/{deansOfficeId}", ResponseFormat = WebMessageFormat.Json)]
    DeansOfficeInfo GetDeansOfficeInfo(string deansOfficeId);

    [OperationContract]
    [WebGet(UriTemplate = "libraries", ResponseFormat = WebMessageFormat.Json)]
    IList<LibraryInfo> GetLibraries();

    [OperationContract]
    [WebGet(UriTemplate = "messages/{departmentId}", ResponseFormat = WebMessageFormat.Json)]
    IList<MessageInfo> GetMessages(string departmentId);

    [OperationContract]
    [WebGet(UriTemplate = "events/{departmentId}", ResponseFormat = WebMessageFormat.Json)]
    IList<EventInfo> GetEvents(string departmentId);

    [OperationContract]
    [WebGet(UriTemplate = "units", ResponseFormat = WebMessageFormat.Json)]
    IList<UnitInfo> GetUnits();
  }
}