using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3
{
    public class Response <T>
    {
        public bool IsError { get; set; }
        public T Data { get; set; }
        public string ErrorDetails { get; set; }

    }
}