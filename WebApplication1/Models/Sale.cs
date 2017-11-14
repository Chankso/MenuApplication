using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Sale
    {

        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public float Percentile { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsOnSale { get; set; }

        public Sale()
        {
            Percentile = 1.00f;
        }
    }
}