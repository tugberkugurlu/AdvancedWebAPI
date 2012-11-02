using _09_PerRouteMHOwnershipSample.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _09_PerRouteMHOwnershipSample.Models {

    public class Customer : IEntity {

        [Key]
        public int Key { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(320)]
        public string Email { get; set; }

        public string HashedPassword { get; set; }
        public string Salt { get; set; }

        virtual public ICollection<Order> Orders { get; set; }
    }
}