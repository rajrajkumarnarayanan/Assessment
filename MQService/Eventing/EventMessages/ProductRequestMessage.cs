using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;

namespace Eventing.EventMessages
{
    [Queue(queueName: "payment.validity.check.queue")]
    public sealed class ProductRequestMessage
    {       
        public string ProductRequest { get; set; }
        public string Id { get; set; }
    }
}
