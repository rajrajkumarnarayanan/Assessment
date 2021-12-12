using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MQService.Model;
using MQService.Extensions;

namespace MQService
{
    internal class ProductContext
    {
        private readonly IMongoCollection<Product> _product;
        private readonly IMongoCollection<PriceReduction> _priceReductions;

        private IMongoCollection<Product> Products { get; }
        private IMongoCollection<PriceReduction> PriceReductions { get; }
        public ProductContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProductDataBase");
            database.CreateDataBaseifNotExist();
            _product = database.GetCollection<Product>("Product");
            _priceReductions = database.GetCollection<PriceReduction>("PriceReduction");
            ContextSeedExtension.SeedData<Product>(_product);
            ContextSeedExtension.SeedData<PriceReduction>(_priceReductions);
        }

        public double GetReducionRate(int DayOfWeek) => _priceReductions.AsQueryable<PriceReduction>().Where(x => x.DayOfWeek == DayOfWeek).Select(x => x.Reduction).FirstOrDefault();
        public List<Product> GetProductList() => _product.Find(p => true).ToList();

        public Product GetProduct(ObjectId id) =>
             _product.Find<Product>(p => p.Id == id).FirstOrDefault();

    }
}
