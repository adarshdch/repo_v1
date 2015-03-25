
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace SAB.DAL.EntLib
{
	public static class DbFactory
	{
		static DbFactory()
		{
			var aFactory = new DatabaseProviderFactory();
			DatabaseFactory.SetDatabaseProviderFactory(aFactory);
		}

		public static Database GetMasterDatabase()
		{
			return GetMasterDatabase("MasterDb");
		}

		public static Database GetMasterDatabase(string theConnectionStringName)
		{
			return DatabaseFactory.CreateDatabase(theConnectionStringName);
		}

		public static Database GetOrgDatabase(string theConnectionStringName)
		{
			return DatabaseFactory.CreateDatabase(theConnectionStringName);
		}
	}
}
