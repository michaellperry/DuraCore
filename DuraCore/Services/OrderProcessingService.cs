using System;
using System.Linq;
using System.Threading;
using System.Transactions;
using DuraCore.Database;
using DuraCore.Infrastructure.Messaging;

namespace DuraCore.Services
{
    public class OrderProcessingService
    {
        private static IMessageQueueOutbound<ProcessOrder> _outbound;
        private static IMessageQueueInbound<ProcessOrder> _inbound;

        static OrderProcessingService()
        {
            // TODO 2: Switch to MSMQ
            // Memory
            var queue = new MemoryMessageQueue<ProcessOrder>();
            _outbound = queue;
            _inbound = queue;

            // MSMQ
            //_outbound = new MsmqMessageQueueOutbound<ProcessOrder>(".", "OrderInbox");
            //_inbound = new MsmqMessageQueueInbound<ProcessOrder>("OrderInbox");
        }

        public static void Run()
        {
            while (true)
            {
                try
                {
                    // TODO 7.5: Begin a transaction scope (requires new, read committed).
                    ProcessOrder message = null;
                    if (_inbound.TryReceive(out message))
                    {
                        ProcessOrder(message.OrderId);
                    }
                }
                catch (Exception x)
                {
                }
            }
        }

        public static void SendProcessOrderMessage(int orderId)
        {
            _outbound.Send(new ProcessOrder
            {
                OrderId = orderId
            });
        }

        public static void ProcessOrder(int orderId)
        {
            // TODO 1: Slow processing.
            //Thread.Sleep(5000);


            // TODO 7.0: Intermittent errors.
            //throw new Exception("A deadlock occurred.");


            using (var context = new OrderContext())
            {
                // TODO 9: Look for existing shipments for order.
                context.Shipments.Add(new Shipment { OrderId = orderId });

                context.SaveChanges();
            }
        }
    }
}