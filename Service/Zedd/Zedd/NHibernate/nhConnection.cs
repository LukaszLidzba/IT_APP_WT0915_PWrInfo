using System.Configuration;
using System.Data.SqlClient;

namespace Zedd.NHibernate
{
  public class NhConnection
  {
    private static SqlConnection NewCon;
    private static string conStr = ConfigurationManager.ConnectionStrings["AppDatabase"].ConnectionString;

    public static SqlConnection GetConnection()
    {
      NewCon = new SqlConnection(conStr);
      return NewCon;
    }
  }
}