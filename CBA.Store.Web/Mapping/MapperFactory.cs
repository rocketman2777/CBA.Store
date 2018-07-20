using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Configuration;
using CBA.Store.Api.Models;
using CBA.Store.Web.Models;

namespace CBA.Store.Web.Mapping
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
                cfg.CreateMap<ProductViewModel, ProductModel>();
                cfg.CreateMap<ProductModel, ProductViewModel>();
            });
            return config.CreateMapper();
        }
    }
}