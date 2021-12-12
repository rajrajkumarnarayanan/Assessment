using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;

namespace Eventing.EventMessages
{
    [Queue(queueName: "payment.validity.check.queue")]
    public sealed class ProductResponseMessage
    {
        public Products Product { get; set; }
        public List<Products> ProductList { get; set; }        
    }
}
