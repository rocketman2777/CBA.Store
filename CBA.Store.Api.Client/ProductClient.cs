using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using CBA.Store.Api.Models;
using CBA.Store.Api.Client.Interface;

namespace CBA.Store.Api.Client
{
    /// <summary>
    /// Product API client
    /// </summary>
    public class ProductClient : ClientBase, IProductClient
    {
        public ProductClient(IRestClient restClient) : base(restClient)
        {
        }

        public ProductModel GetProduct(long productId)
        {
            return Execute<ProductModel>($"/product/{productId}", Method.GET);
        }

        public List<ProductModel> GetProducts()
        {
            return Execute<List<ProductModel>>("/product", Method.GET);
        }
    }
}