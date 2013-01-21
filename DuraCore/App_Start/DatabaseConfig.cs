using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DuraCore.Database;

namespace DuraCore
{
    public class DatabaseConfig
    {
        public static void RegisterDatabase()
        {
            System.Data.Entity.Database.SetInitializer<OrderContext>(
                new DropCreateDatabaseIfModelChanges<
                    OrderContext>());
        }
    }
}