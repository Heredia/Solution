using System.Configuration;

namespace System.Web.Mvc
{
    public static class AppSettingsHelper
    {
        public static readonly string Guid = AppSetting(nameof(Guid));

        private static string AppSetting(string name)
        {
            if (ConfigurationManager.AppSettings[name] == null)
                throw new Exception($"AppSettings '{name}' not exists in .config file.");

            return ConfigurationManager.AppSettings[name];
        }
    }
}