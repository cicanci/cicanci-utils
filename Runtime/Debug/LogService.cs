
namespace Cicanci.Utils
{
    public class LogService : BaseService
    {
        public delegate void LogHandler(string message);

#if ENABLE_LOG
        public LogHandler Log = UnityEngine.Debug.Log;
#else
        public LogHandler Log = (message) => { };
#endif
        public LogHandler LogWarn = UnityEngine.Debug.LogWarning;
        public LogHandler LogError = UnityEngine.Debug.LogError;
    }
}
