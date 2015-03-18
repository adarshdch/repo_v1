
namespace SAB.Infra.Config
{
	public static class WebConfig
	{
		public static class AppSetting
		{
			public static string PageBasePath
			{
				get { return WebConfigReader.AppSetting.Get("PageBasePath", @"C:\D\Git\repo\static\pages\"); }
			}

			public static string TemplateBasePath
			{
				get { return WebConfigReader.AppSetting.Get("TemplateBasePath", @"C:\D\Git\repo\static\stylesheets\"); }
			}
		}
	}
}
