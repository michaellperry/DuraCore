using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DuraCore.Database
{
    public class Order
    {
        [Key]
        public virtual int OrderId { get; set; }

        [Required]
        [StringLength(50)]
        public virtual string Item { get; set; }
		
        // TODO 8.1: Add Uniquifier.
        [Required]
        public virtual Guid Uniquifier { get; set; }
    }
}
