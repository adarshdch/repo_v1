
using System.Data;

namespace SAB.Framework.DbRepository.Repositories
{
		public interface IRepository
		{
			DataTable SelectQuery(string theSqlQuery, params object[] theParameters);
		}
}