
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SAB.DAL.EntLib
{
	public class DbProviderFactory
	{
		private static readonly DatabaseProviderFactory _databaseProviderFactory;

		static DbProviderFactory()
		{
			_databaseProviderFactory = new DatabaseProviderFactory();
		}

		
		public static Database GetMasterDatabase()
		{
			return GetMasterDatabase("MasterDb");
		}

		public static Database GetMasterDatabase(string theConnnectionStringName)
		{
			return _databaseProviderFactory.Create(theConnnectionStringName);
		}


		public static SqlDatabase GetMasterSqlDatabase()
		{
			return GetMasterSqlDatabase("MasterDb");
		}

		public static SqlDatabase GetMasterSqlDatabase(string theConnnectionStringName)
		{
			return _databaseProviderFactory.Create(theConnnectionStringName) as SqlDatabase;
		}

	}
}
