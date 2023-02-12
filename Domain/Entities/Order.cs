using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public double ProductAmount { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public Product Product{ get;set;}
        [Required]
        public InstallmentEnum Installment { get; set; }
        public double Percent { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string PhoneNumber { get; set; }

    }
    public enum InstallmentEnum
    {
        Three = 3,
        Six = 6,
        Nine = 9,
        Twelve = 12,
        Eighteen = 18,
        TwentyFour = 24
    };
}