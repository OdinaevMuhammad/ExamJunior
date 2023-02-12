using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
namespace Domain.Dtos
{
    public class GetOrders
    {

        public int Id { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }
        public double ProductAmount { get; set; }
        public string ProductName { get; set; }
        public int ProductId { get; set; }
        public int Installment { get; set; }
        public double Percent { get; set; }
        public DateTime StartDate { get; set; }
        public string PhoneNumber { get; set; }

    }
}