using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;
namespace Domain.Dtos
{
    public class OrderDto
    {

        [Required]
        public ProductCategory CategoryName { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        public string ProductName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public InstallmentEnum Installment { get; set; }


    }
}