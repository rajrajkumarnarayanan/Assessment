using Eventing.EventMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface IProductService
    {
        Task<ProductResponseMessage> Get();
        Task<ProductResponseMessage> Get(string id);
    }
}
