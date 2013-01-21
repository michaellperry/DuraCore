using System.Collections.Generic;
using System.Linq;
using System;

namespace DuraCore.Infrastructure.Messaging
{
    public interface IMessageQueueInbound<T>
    {
        bool TryReceive(out T message);
    }
}
