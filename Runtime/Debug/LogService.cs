using System.Diagnostics;

namespace Cicanci.Utils
{
    public class LogService : BaseService
    {
        [Conditional("ENABLE_DEBUG_LOG")]
        public void Log(string message)
        {
            UnityEngine.Debug.Log(message);
        }

        [Conditional("ENABLE_DEBUG_LOG")]
        public void LogWarn(string message)
        {
            UnityEngine.Debug.LogWarning(message);
        }

        [Conditional("ENABLE_DEBUG_LOG")]
        public void LogError(string message)
        {
            UnityEngine.Debug.LogError(message);
        }
    }
}

