using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dynamicslink1.Models
{
    public class MyModel
    {
        [Required]
        public int? Item { get; set; }

        [Required]
        public int? Unit { get; set; }

        [Required]
        public int? Price { get; set; }

        [Required]
        public int? Qty { get; set; }

        [Required]
        public int? Total { get; set; }

        [Required]
        public int? Discount { get; set; }

        [Required]
        public int? Net { get; set; }
    }
}