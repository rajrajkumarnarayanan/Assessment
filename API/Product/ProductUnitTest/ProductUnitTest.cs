using Business;
using Business.Interface;
using Eventing.EventMessages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Product.Controllers;
using System.IO;
using System.Threading.Tasks;

namespace ProductUnitTest
{
    [TestClass]
    public class ProductUnitTest
    {
        [TestMethod]
        public async Task ProductGetMethod()
        {
            ProductController product = new ProductController(GetProductService());
            var outValue = await product.Get();
            Assert.IsNotNull(outValue);
        }

        [TestMethod]
        public async Task ProductGetByID()
        {
            ProductController product = new ProductController(GetProductService());
            var outValue = await product.Get("61b1a919242ba604bba3fb0b");
            Assert.IsNotNull(outValue);
        }

        private IProductService GetProductService()
        {
            var productService = new Mock<IProductService>();
            var output = JsonConvert.DeserializeObject<ProductResponseMessage>(File.ReadAllText("productdata.json"));
            
            productService.Setup(x => x.Get()).ReturnsAsync(output);
            productService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(new ProductResponseMessage {Product = new Products { Id= "61b1a919242ba604bba3fb0b",ProductName= "A pile of potatoes" } });


            return productService.Object;

        }


    }
}
