using _09_PerRouteMHOwnershipSample.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models {

    public class Order : IEntity {

        [Key]
        public int Key { get; set; }
        public int CustomerKey { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public DateTime PurchasedOn { get; set; }

        public Customer Customer { get; set; }
    }
}