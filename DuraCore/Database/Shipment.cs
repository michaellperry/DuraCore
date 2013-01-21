using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DuraCore.Database
{
    public class Shipment
    {
        [Key]
        public virtual int ShipmentId { get; set; }

        [Required]
        public virtual int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
    }
}
