using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DuraCore.Models
{
    public class ShoppingCart
    {
        public string Item { get; set; }
        public Guid Uniquifier { get; set; }
    }
}