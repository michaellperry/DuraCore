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
            // TODO 7.1: Begin a transaction scope (requires new, read committed).
            // TODO 5: Send to outbound queue.
            // TODO 6: Make message recoverable.
            // TODO 7.2: Automatically enlist in current transaction.
            // TODO 7.3: Complete the transaction.
        }
    }
}
