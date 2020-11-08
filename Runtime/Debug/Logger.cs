
namespace Cicanci.Utils
{
    internal static class Logger
    {
        internal delegate void LogHandler(string message);

        internal static LogHandler Log = UnityEngine.Debug.Log;
        internal static LogHandler LogWarn = UnityEngine.Debug.LogWarning;
        internal static LogHandler LogError = UnityEngine.Debug.LogError;
    }
}