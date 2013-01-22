using System;
using System.Messaging;
using System.Transactions;

namespace DuraCore.Infrastructure.Messaging
{
    public class MsmqMessageQueueOutbound<T> :
        IMessageQueueOutbound<T>
    {
        private XmlMessageFormatter Formatter =
            new XmlMessageFormatter(
                new Type[] { typeof(T) });

        private string _path;

        public MsmqMessageQueueOutbound(
            string target, string queueName)
        {
            _path = target + @"\private$\" + queueName;
        }

        public void Send(T message)
        {
        }
    }
}
