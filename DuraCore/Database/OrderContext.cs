using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DuraCore.Database
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("DuraCore") { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
    }
}