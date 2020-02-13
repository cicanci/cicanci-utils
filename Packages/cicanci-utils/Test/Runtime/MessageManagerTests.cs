using NUnit.Framework;

namespace Cicanci.Utils.Tests
{
    public class MessageManagerTests
    {
        [Test]
        public void MessageManagerTestSendMessage()
        {
            MessageManager.Instance.AddListener<MessageTest>(OnMessageTest1);

            MessageManager.Instance.SendMessage(new MessageTest { Number = 42 });

            MessageManager.Instance.RemoveListener<MessageTest>(OnMessageTest1);
        }

        private void OnMessageTest1(MessageTest message)
        {
            Assert.IsTrue(message.Number == 42);
        }

        [Test]
        public void MessageManagerTestAddRemoveListeners()
        {
            MessageManager.Instance.AddListener<MessageTest>(OnMessageTest2);

            Assert.IsTrue(MessageManager.Instance.SendMessage(new MessageTest()));

            MessageManager.Instance.RemoveListener<MessageTest>(OnMessageTest2);

            Assert.IsFalse(MessageManager.Instance.SendMessage(new MessageTest()));
        }

        private void OnMessageTest2(MessageTest message)
        {

        }
    }

    internal class MessageTest
    {
        public int Number;
    }
}
