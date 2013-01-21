using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DuraCore.Models
{
    public class Confirmation
    {
        public string Item { get; set; }

        [Display(Name = "Confirmation Number")]
        public string ConfirmationNumber { get; set; }
    }
}