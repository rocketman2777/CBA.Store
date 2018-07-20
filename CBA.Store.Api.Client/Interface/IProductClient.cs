using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CBA.Store.Api.Models;

namespace CBA.Store.Api.Client.Interface
{
    public interface IProductClient
    {
        ProductModel GetProduct(long productId);
        List<ProductModel> GetProducts();
    }
}
