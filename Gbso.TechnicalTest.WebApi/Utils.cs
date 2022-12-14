namespace Gbso.TechnicalTest.WebApi
{
	public static class Utils
	{
		public const string CONNECTION_ROOT_NAME = "gbso.technicaltest.database";
		public const string CONNECTION_MIGRATIONS_NAME = "gbso.technicaltest.database.migrations";
		public const string FILE_CONFIGURATION_NAME = "appsettings.json";
		public const string DEVELOPMENT_FILE_CONFIGURATION_NAME = "appsettings.Development.json";

		public static IConfigurationRoot BuildConfiguration()
		{
			var configurationResult = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
#if !DEBUG
				.AddJsonFile(FILE_CONFIGURATION_NAME, optional: false, reloadOnChange: true)
#else
				.AddJsonFile(DEVELOPMENT_FILE_CONFIGURATION_NAME, optional: false, reloadOnChange: true)
#endif
				.Build();
			return configurationResult;
		}
	}
}
