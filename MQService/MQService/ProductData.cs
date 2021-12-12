using Eventing.EventMessages;
using MQService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQService
{
    public class ProductData
    {
        readonly ProductContext context = new ProductContext();
        public ProductResponseMessage GetProductDetails(string Id)
        {

            var response = new ProductResponseMessage
            {
                Product = new Products()
            };
            var reductionRate = context.GetReducionRate(((int)DateTime.Now.DayOfWeek + 6) % 7 + 1);
            var prdDetail = context.GetProduct(new MongoDB.Bson.ObjectId(Id));
            if (prdDetail != null)
            {
                response.Product = new Products
                {
                    Id = prdDetail.Id.ToString(),
                    ProductName = prdDetail.ProductName,
                    EntryDate = prdDetail.EntryDate,
                    PriceWithReduction = reductionRate != 0 ? prdDetail.Price * reductionRate : prdDetail.Price
                };
            }
            return response;
        }
        public ProductResponseMessage GetProduct()
        {
            var response = new ProductResponseMessage();
            response.ProductList = new List<Products>();
            var reductionRate = context.GetReducionRate(((int)DateTime.Now.DayOfWeek + 6) % 7 + 1);
            var products = context.GetProductList();
            products.ForEach(i => response.ProductList.Add(CreateProduct(i, reductionRate)));          
            return response;
        }

        private Products CreateProduct(Product i,double reductionRate)
        {
            return new Products
            {
                Id = i.Id.ToString(),
                    ProductName = i.ProductName,
                    EntryDate = i.EntryDate,
                    PriceWithReduction = reductionRate != 0 ? i.Price * reductionRate : i.Price

                };
        }
    }
}

