using System.Configuration;

namespace AudioOutput_Manager.Utility
{
    public static class ConfigManager
    {
        public static int CycledHotKeyId { get; } = int.Parse(ConfigurationManager.AppSettings.Get("cycledHotKeyId"));
    }
}