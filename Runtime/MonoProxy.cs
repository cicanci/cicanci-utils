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

        public delegate void AwakeEventHandler();
        public delegate void StartEventHandler();
        public delegate void DestroyEventHandler();
        public delegate void UpdateEventHandler();

        public event AwakeEventHandler AwakeEvent;
        public event StartEventHandler StartEvent;
        public event DestroyEventHandler DestroyEvent;
        public event UpdateEventHandler UpdateEvent;

        private void Awake()
        {
            AwakeEvent?.Invoke();
        }

        private void Start()
        {
            StartEvent?.Invoke();
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke();
        }

        private void Update()
        {
            UpdateEvent?.Invoke();
        }
    }
}