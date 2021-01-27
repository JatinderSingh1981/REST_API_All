using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.REST_API
{
    [Table("Laptops")]
    public class ProductLaptop : CommonProduct
    {
        [Required]
        public int ScreenSize { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        //[Required]
        //public int ProductId { get; set; }
        //public Product Product { get; set; }
    }
}
