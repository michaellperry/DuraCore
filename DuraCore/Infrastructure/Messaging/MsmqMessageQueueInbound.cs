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
            if (!MessageQueue.Exists(_path))
                MessageQueue.Create(_path,
    				// TODO 7.1: Make queue transactional (remember to drop queue).
                    transactional: true);
        }

        public bool TryReceive(out T message)
        {
            try
            {
            	// TODO 4: Receive from inbound queue.
                using (var queue = new MessageQueue(_path))
                {
                    queue.Formatter = Formatter;
                    var queueMessage = queue.Receive(Timeout,
        				// TODO 7.6: Automatically enlist in current transaction.
                        MessageQueueTransactionType.Automatic);
                    message = (T)queueMessage.Body;
                    return true;
                }
            }
            catch (Exception x)
            {
                message = default(T);
                return false;
            }
        }
    }
}
