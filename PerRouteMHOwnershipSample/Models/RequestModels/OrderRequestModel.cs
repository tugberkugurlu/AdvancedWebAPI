using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models.RequestModels {
    
    public class OrderRequestModel {

        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        public decimal Price { get; set; }
    }
}