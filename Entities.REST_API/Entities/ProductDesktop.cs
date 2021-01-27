using Common.REST_API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.REST_API
{
    public abstract class CommonProduct
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    [Table("Desktops")]
    public class ProductDesktop : CommonProduct
    {
        [NotMapped]
        public FormFactor FormFactor { get; set; }
        [Required]
        public int FormFactorId { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }

        
    }
}
