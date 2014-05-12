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
            // TODO 3: Create queue.
    		// TODO 7.1: Make queue transactional (remember to drop queue).
        }

        public bool TryReceive(out T message)
        {
            // TODO 4: Receive from inbound queue.
        	// TODO 7.6: Automatically enlist in current transaction.
            message = default(T);
            return false;
        }
    }
}
