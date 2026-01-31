using System.Configuration;

namespace Oracle.Utilities
{
    internal static class ConfigurationUtility
    {
        public static string FileExplorer = ConfigurationManager.AppSettings["FileExplorer"] ?? "Explorer.exe";
    }
}