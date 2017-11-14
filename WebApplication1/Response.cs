﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsError { get; set; }
        public string ErrorDetails { get; set; }

       
    }
}