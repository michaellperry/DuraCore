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
            // TODO 7.2: Begin a transaction scope (requires new, read committed).
            using (var scope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions
                {
                    IsolationLevel = IsolationLevel.ReadCommitted
                }))
            {
            	// TODO 5: Send to outbound queue.
                using (var queue = new MessageQueue(_path))
                {
            		// TODO 6: Make message recoverable.
                    queue.DefaultPropertiesToSend.Recoverable = true;
                    queue.Formatter = Formatter;
                    queue.Send(message,
            			// TODO 7.3: Automatically enlist in current transaction.
                        MessageQueueTransactionType.Automatic);
                }
            	// TODO 7.4: Complete the transaction.
                scope.Complete();
            }
        }
    }
}
