using UnityEngine;

namespace Cicanci.Utils
{
    public class MonoProxy : MonoBehaviour
    {
        private static MonoProxy _instance;
        public static MonoProxy Instance
        {
            get
            {
                if (_instance == null)
                {
                    var singletonObject = new GameObject("_MonoProxy");
                    _instance = singletonObject.AddComponent<MonoProxy>();
                    DontDestroyOnLoad(singletonObject);
                }
                return _instance;
            }
        }

        public delegate void UpdateEventHandler();

        public event UpdateEventHandler UpdateEvent;

        private void Update()
        {
            UpdateEvent?.Invoke();
        }
    }
}