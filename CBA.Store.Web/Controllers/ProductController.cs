using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RestSharp;
using CBA.Store.Api.Client.Interface;
using CBA.Store.Web.Models;
using CBA.Store.Web.Mapping;

namespace CBA.Store.Web.Controllers
{
    /// <summary>
    /// Controller for product related pages
    /// </summary>
    public class ProductController : Controller
    {
        private IProductClient _productClient;
        private IMapper _mapper;

        public ProductController(IProductClient productClient, IMapper mapper)
        {
            _productClient = productClient;
            _mapper = mapper;
        }

        public ActionResult Listing()
        {
            var products = _productClient.GetProducts();
            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public ActionResult Details(long id)
        {
            var product = _productClient.GetProduct(id);
            return View(_mapper.Map<ProductViewModel>(product));
        }

    }
}