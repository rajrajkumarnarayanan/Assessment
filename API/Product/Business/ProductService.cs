using Business.Interface;
using Business.Proxy;
using EasyNetQ;
using Eventing;
using Eventing.EventMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public sealed class ProductService : IProductService
    {
        private readonly IBus bus;
        public ProductService(MessageQueueProxy messageQueueProxy)
        {            
            
            bus = RabbitHutch.CreateBus(
            connectionString: messageQueueProxy.URL,
            registerServices: s =>
            {
                s.Register<ITypeNameSerializer, EventBusTypeNameSerializer>();
                s.Register<IConventions, EventBusConventions>();
            });
        }        

        public async Task<ProductResponseMessage> Get()
        {
          return await bus.Rpc.RequestAsync<ProductRequestMessage, ProductResponseMessage>(new ProductRequestMessage
            {
                ProductRequest = "Product"
            }).ConfigureAwait(false);          
        }

        public async Task<ProductResponseMessage> Get(string id)
        {
           return await bus.Rpc.RequestAsync<ProductRequestMessage, ProductResponseMessage>(new ProductRequestMessage
            {
                ProductRequest = "Product Details",
                Id = id
            }).ConfigureAwait(false);
        }
    }
}
