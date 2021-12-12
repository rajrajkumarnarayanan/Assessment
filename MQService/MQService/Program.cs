using EasyNetQ;
using Eventing;
using Eventing.EventMessages;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


namespace MQService
{
    class Program
    {
        private readonly static IBus bus = RabbitHutch.CreateBus(
            connectionString: "host=localhost;timeout=60;virtualHost=/;username=guest;password=guest",
            registerServices: s =>
            {
                s.Register<ITypeNameSerializer, EventBusTypeNameSerializer>();
                s.Register<IConventions, EventBusConventions>();
            });

        static async Task Main(string[] args)
        {
            ProductData prductController = new ProductData();
            try
            {
                await bus.Rpc.RespondAsync<ProductRequestMessage, ProductResponseMessage>(request =>
                {

                    Console.WriteLine($"Received request: {JsonConvert.SerializeObject(request)}");

                    if (request.ProductRequest == "Product")
                    {
                        return prductController.GetProduct();
                    }
                    else if (request.ProductRequest == "Product Details")
                    {
                        return prductController.GetProductDetails(request.Id);
                    }
                    else
                    {
                        return null;
                    }

                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadLine(); // to keep running the console app
        }
    }
}
