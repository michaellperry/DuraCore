using System.Threading;
using DuraCore.Services;

namespace DuraCore
{
    public class ServiceConfig
    {
        public static void StartService()
        {
            Thread thread = new Thread(OrderProcessingService.Run);
            thread.Name = "Order Processing Thread";
            thread.IsBackground = true;
            thread.Start();
        }
    }
}