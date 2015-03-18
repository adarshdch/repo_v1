
using System.Configuration;

namespace SAB.Infra.Config
{
	public static class WebConfigReader
	{
		public static class AppSetting
		{
			public static string Get(string theKey)
			{
				var aValue = ConfigurationManager.AppSettings[theKey] ??  string.Empty;
				return aValue;
			}

			public static string Get(string theKey, string theDefaultValue)
			{
				var aValue = Get(theKey);
				if (string.IsNullOrWhiteSpace(aValue))
					aValue = theDefaultValue;
				return aValue;
			}
		}
	}
}
