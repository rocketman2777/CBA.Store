using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CBA.Store.Domain
{
    public class Product
    {
        public long ProductId { get; set; }
        [MaxLength(250)]
        [Required]
        public string Name { get; set; }
        [MaxLength(1000)]
        [Required]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
