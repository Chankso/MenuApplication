using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Branch
    {
        public int BranchId { get; set;}
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public int CompanyId { get; set; }
        public string PhysAddress { get; set; }
        public string OpenClose { get; set; }
        public string PhoneNumber { get;set; }


    }
}