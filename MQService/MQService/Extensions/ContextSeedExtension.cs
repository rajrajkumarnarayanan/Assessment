using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MQService.Model;

namespace MQService.Extensions
{
    public static class ContextSeedExtension
    {      
        public static void SeedData<TEntity>(IMongoCollection<TEntity> priceCollection)
        {
            bool _isExist = priceCollection.Find(p => true).Any();
            if (!_isExist)
            {
                switch (typeof(TEntity).Name)
                {
                    case "Product":
                        priceCollection.InsertManyAsync((IEnumerable<TEntity>)GeProductsCollection());
                        break;
                    case "PriceReduction":
                        priceCollection.InsertManyAsync((IEnumerable<TEntity>)GetPriceReduction());
                        break;
                    default:
                        break;
                }
                
            }
        }       
        private static IEnumerable<Product> GeProductsCollection()
        {
            return new List<Product>()
            {
                new Product(){
                    Id= ObjectId.GenerateNewId(),
                    ProductName = "Uncle Ben's Rice",
                    EntryDate =DateTime.Now,
                    Price =300
                },
                new Product(){
                    Id= ObjectId.GenerateNewId(),
                    ProductName = "A pile of potatoes",
                    EntryDate =DateTime.Now,
                    Price =350
                }
            };
        }

        private static IEnumerable<PriceReduction> GetPriceReduction()
        {
            return new List<PriceReduction>()
            {
                new PriceReduction(){
                    DayOfWeek =1,
                    Reduction =0,
                },
                new PriceReduction(){
                    DayOfWeek =2,
                    Reduction =0,
                },
                new PriceReduction(){
                    DayOfWeek =3,
                    Reduction =0,
                },
                new PriceReduction(){
                    DayOfWeek =4,
                    Reduction =0,
                },
                new PriceReduction(){
                    DayOfWeek =5,
                    Reduction =0,
                },new PriceReduction(){
                    DayOfWeek =6,
                    Reduction =0.2,
                },
                new PriceReduction(){
                    DayOfWeek =7,
                    Reduction =0.5,
                }
            };
        }
    }
}
