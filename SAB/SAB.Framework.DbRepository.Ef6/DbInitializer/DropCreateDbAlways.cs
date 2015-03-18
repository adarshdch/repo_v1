

using System.Data.Entity;

namespace SAB.Framework.DbRepository.Ef6.DbInitializer
{
	public class DropCreateDbAlways<TContext> : DropCreateDatabaseAlways<TContext> where TContext : DbContext
	{
		public DropCreateDbAlways()
		{
		}

		protected override void Seed(TContext context)
		{
			base.Seed(context);
		}
	}
}
