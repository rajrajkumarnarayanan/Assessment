﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eventing.EventMessages
{
    public class Products
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public DateTime EntryDate { get; set; }
        public double PriceWithReduction { get; set; }
    }
}
