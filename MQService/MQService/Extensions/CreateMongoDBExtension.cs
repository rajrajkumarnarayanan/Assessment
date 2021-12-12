using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace MQService.Extensions
{
    public static class CreateMongoDBExtension
    {
        public static void CreateDataBaseifNotExist(this IMongoDatabase database)
        {
            try
            {
                database.CreateCollection("Product");
                database.CreateCollection("PriceReduction");
            }
            catch (Exception)
            {
                
            }
        }
    }
}
