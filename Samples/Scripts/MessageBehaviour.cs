using Cicanci.Utils;
using UnityEngine;
using UnityEngine.UI;

public class MessageBehaviour : MonoBehaviour
{
    [SerializeField]
    private Text _counterText = null;

    private int _counter;

    private void Start()
    {
        MessageManager.Instance.AddListener<MessageCounter>(OnMessageCounter);
    }

    private void OnDestroy()
    {
        MessageManager.Instance.RemoveListener<MessageCounter>(OnMessageCounter);
    }

    private void OnMessageCounter(MessageCounter message)
    {
        _counterText.text = message.Counter.ToString();
    }

    public void IncreaseCounter()
    {
        _counter++;
        MessageManager.Instance.SendMessage(new MessageCounter { Counter = _counter });
    }

    public void DecreaseCounter()
    {
        _counter--;
        MessageManager.Instance.SendMessage(new MessageCounter { Counter = _counter });
    }
}

internal class MessageCounter
{
    public int Counter;
}