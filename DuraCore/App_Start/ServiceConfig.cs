using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using DuraCore.Services;

namespace DuraCore
{
    public class ServiceConfig
    {
        public static void StartService()
        {
            OrderProcessingService service = new OrderProcessingService();

            Thread thread = new Thread(new ThreadStart(delegate() { service.Run(); }));
            thread.Name = "Order Processing Thread";
            thread.IsBackground = true;
            thread.Start();
        }
    }
}