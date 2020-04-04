using UnityEngine;
using UnityEngine.UI;

namespace Cicanci.Utils.Samples
{
    public class MonoProxySample : MonoBehaviour
    {
        [SerializeField]
        private Text _messageText = null;

        private PrintMessage _printMessage;

        private void Awake()
        {
            _printMessage = new PrintMessage();
        }

        public void AddUpdate()
        {
            _printMessage.AddUpdate();
            _messageText.text = "Added update event!";
        }

        public void RemoveUpdate()
        {
            _printMessage.RemoveUpdate();
            _messageText.text = "Removed update event!";
        }

        private class PrintMessage
        {
            public void AddUpdate()
            {
                MonoProxy.Instance.UpdateEvent += OnUpdate;
            }

            public void RemoveUpdate()
            {
                MonoProxy.Instance.UpdateEvent -= OnUpdate;
            }

            private void OnUpdate()
            {
                Debug.Log("Update from MonoProxy was called!");
            }
        }
    }
}