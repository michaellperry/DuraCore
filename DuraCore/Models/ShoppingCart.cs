using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraCore.Models
{
    public class ShoppingCart
    {
        // TODO 8.2: Add uniquifier.
        public Guid Uniquifier { get; set; }
        public string Item { get; set; }
    }
}