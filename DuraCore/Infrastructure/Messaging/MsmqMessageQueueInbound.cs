using System;
using System.Messaging;
using System.Transactions;

namespace DuraCore.Infrastructure.Messaging
{
    public class MsmqMessageQueueInbound<T> :
        IMessageQueueInbound<T>
    {
        private static readonly TimeSpan Timeout =
            TimeSpan.FromSeconds(5.0);
        private XmlMessageFormatter Formatter =
            new XmlMessageFormatter(
                new Type[] { typeof(T) });

        private string _path;

        public MsmqMessageQueueInbound(string queueName)
        {
            _path = @".\private$\" + queueName;
        }

        public bool TryReceive(out T message)
        {
            message = default(T);
            return false;
        }
    }
}
