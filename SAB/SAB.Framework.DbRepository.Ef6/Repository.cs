
using System.Data;
using System.Data.SqlClient;
using SAB.Framework.DbRepository.Repositories;

namespace SAB.Framework.DbRepository.Ef6
{
	public class Repository : IRepository
	{
		public string ConnectionString { get; protected set; }

		public Repository()
		{
			ConnectionString = @"Data Source=.;Initial Catalog=MasterDb;Integrated Security=SSPI;User ID=sa;Password=Test123!@#;";
		}
		public Repository(string theConnectionString)
		{
			ConnectionString = theConnectionString;
		}
		public DataTable SelectQuery(string theSqlQuery, params object[] theParameters)
		{
			var aDataTable = new DataTable();

			using (var aConnection = new SqlConnection(ConnectionString))
			{
				using (var aCommand = new SqlCommand(theSqlQuery, aConnection))
				{
					aConnection.Open();
					using (var aReader = aCommand.ExecuteReader())
					{
							aDataTable.Load(aReader);
					}
				}
			}

			return aDataTable;
		}
	}
}
