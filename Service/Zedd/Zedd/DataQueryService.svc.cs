using System;
using System.Collections.Generic;
using System.Security;
using System.ServiceModel;
using System.Web.Configuration;
using Zedd.Commands;
using Zedd.Dto;
using Zedd.Queries;

namespace Zedd
{
  public class DataQueryService : IDataQueryService
  {
    private readonly IDeansOfficeQuery _deansOfficeQuery;
    private readonly ILoginQueryDao _loginQuery;
    private readonly ISessionGenerator _sessionGenerator;

    public DataQueryService()
      : this(null, null, null)
    {
    }

    public DataQueryService(IDeansOfficeQuery deansOfficeQuery, ILoginQueryDao loginQuery, ISessionGenerator sessionGenerator)
    {
      _deansOfficeQuery = deansOfficeQuery ?? new DeansOfficeQuery();
      _loginQuery = loginQuery ?? new LoginQueryDao();
      _sessionGenerator = sessionGenerator ?? new SessionGenerator();
    }

    public DeansOfficeInfo GetDeansOfficeInfo(int id, Guid ticket)
    {
      DeansOfficeInfo deansOfficeInfo;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        deansOfficeInfo = _deansOfficeQuery.GetDeansOfficeById(id);
      }
      catch (SecurityException e)
      {
        throw new FaultException(e.Message);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }

      return deansOfficeInfo;
    }

    public IList<DeansOfficeInfo> GetAllDeansOffices(Guid ticket)
    {
      IList<DeansOfficeInfo> deansOfficeInfo;

      try
      {
        _loginQuery.IsAuthenticated(ticket);
        _sessionGenerator.ProlongSession(ticket);

        deansOfficeInfo = _deansOfficeQuery.GetAllDeansOffices();
      }
      catch (SecurityException e)
      {
        throw new FaultException<SecurityException>(e);
      }
      catch (Exception e)
      {
        throw new FaultException(e.Message);
      }

      return deansOfficeInfo;
    }
  }
}