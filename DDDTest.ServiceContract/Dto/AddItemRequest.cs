﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDTest.ServiceContract.Dto
{
    public class AddItemRequest
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
