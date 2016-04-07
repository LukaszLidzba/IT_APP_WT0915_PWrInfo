using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using Zedd.Commands;

namespace Zedd.NHibernate
{
  public class NHibernateHelper
  {
    private static ISessionFactory _sessionFactory;

    private static ISessionFactory SessionFactory
    {
      get
      {
        if (_sessionFactory == null)

          InitializeSessionFactory();
        return _sessionFactory;
      }
    }

    private static void InitializeSessionFactory()
    {
      _sessionFactory = Fluently.Configure()
        .Database(MsSqlConfiguration.MsSql2012
          .ConnectionString(ConfigurationManager.ConnectionStrings["AppDatabase"].ConnectionString)
          .ShowSql()
        )
        .Mappings(m => m.FluentMappings
          .AddFromAssemblyOf<LoginHandler>())
        .BuildSessionFactory();
    }

    public static ISession OpenSession()
    {
      return SessionFactory.OpenSession();
    }
  }
}