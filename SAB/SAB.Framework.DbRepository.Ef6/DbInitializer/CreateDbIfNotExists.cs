
using System.Data.Entity;

namespace SAB.Framework.DbRepository.Ef6.DbInitializer
{
	public class CreateDbIfNotExists<TContext> : CreateDatabaseIfNotExists<TContext> where TContext : DbContext
	{
		public CreateDbIfNotExists()
		{
		}

		protected override void Seed(TContext context)
		{
			base.Seed(context);
		}
	}
}
