using System;

namespace DuraCore.Infrastructure.Messaging
{
    public interface IMessageHandler<T> : IDisposable
    {
        void HandleMessage(T message);
    }
}
