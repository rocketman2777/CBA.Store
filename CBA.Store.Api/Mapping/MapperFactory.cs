using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using CBA.Store.Domain;
using CBA.Store.Api.Models;

namespace CBA.Store.Api.Mapping
{
    /// <summary>
    /// Factory for creating Automapper mapper, currently configures maps however
    /// this could be externalised once the solution out grows this class
    /// </summary>
    public class MapperFactory
    {
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<ProductModel, Product>();
            });
            return config.CreateMapper();
        }
    }
}