using Common.REST_API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.REST_API
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [NotMapped]
        public ProductType ComputerType { get; set; }
        [Required]
        public int ComputerTypeId { get; set; }
        [NotMapped]
        public ProcessorType Processor { get; set; }
        [Required]
        public int ProcessorId { get; set; }
        [NotMapped]
        public Brand Brand { get; set; }
        [Required]
        public int BrandId { get; set; }
        [Required]
        public int USBPorts { get; set; }
        [Required]
        public int RamSlots { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string Description { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
        public ProductDesktop ProductDesktop { get; set; }
        public ProductLaptop ProductLaptop { get; set; }
    }
}
