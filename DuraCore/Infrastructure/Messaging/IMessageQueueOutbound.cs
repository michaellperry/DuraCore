using System.Collections.Generic;
using System.Linq;
using System;

namespace DuraCore.Infrastructure.Messaging
{
    public interface IMessageQueueOutbound<T>
    {
        void Send(T message);
    }
}
