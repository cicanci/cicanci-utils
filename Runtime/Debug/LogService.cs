using System.Diagnostics;

namespace Cicanci.Utils
{
    public class LogService : BaseService
    {
        [Conditional("DEBUG_LOG")]
        public void Log(string message)
        {
            UnityEngine.Debug.Log($"[{GetType()}] {message}");
        }

        public void LogWarn(string message)
        {
            UnityEngine.Debug.LogWarning($"[{GetType()}] {message}");
        }

        public void LogError(string message)
        {
            UnityEngine.Debug.LogError($"[{GetType()}] {message}");
        }
    }
}

