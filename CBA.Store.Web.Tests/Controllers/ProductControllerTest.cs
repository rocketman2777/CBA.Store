using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CBA.Store.Api.Client;
using CBA.Store.Api.Models;
using CBA.Store.Api.Client.Interface;
using CBA.Store.Web;
using CBA.Store.Web.Mapping;
using CBA.Store.Web.Controllers;
using CBA.Store.Web.Models;

namespace CBA.Store.Web.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController _productController;
        private Mock<IProductClient> _productClientMock;

        [TestInitialize]
        public void SetupForTest()
        {
            _productClientMock = new Mock<IProductClient>();
            _productController = new ProductController(_productClientMock.Object, MapperFactory.CreateMapper());
        }

        [TestMethod]
        public void ListingNoResults()
        {
            _productClientMock.Setup(pc => pc.GetProducts()).Returns(new List<ProductModel>());
            ViewResult result = _productController.Listing() as ViewResult;
            var resultsModel = result.Model as List<ProductViewModel>;
            Assert.IsNotNull(resultsModel);
            Assert.IsTrue(resultsModel.Count == 0);
        }

        [TestMethod]
        public void ListingWithResults()
        {
            var results = new List<ProductModel>()
            {
                new ProductModel {  ProductId = 1, Name = "Test 1", Description = "Test 1 Desc", Price = 10 },
                new ProductModel {  ProductId = 2, Name = "Test 2", Description = "Test 2 Desc", Price = 20 }
            };
            _productClientMock.Setup(pc => pc.GetProducts()).Returns(results);
            ViewResult result = _productController.Listing() as ViewResult;
            var resultsModel = result.Model as List<ProductViewModel>;
            Assert.IsNotNull(resultsModel);
            Assert.IsTrue(resultsModel.Count == 2);
            Assert.IsTrue(resultsModel[0].ProductId == 1);
            Assert.IsTrue(resultsModel[1].ProductId == 2);
        }

        [TestMethod]
        public void DetailsNoResults()
        {
            _productClientMock.Setup(pc => pc.GetProduct(It.IsAny<long>())).Returns((ProductModel)null);
            ViewResult result = _productController.Details(1) as ViewResult;
            Assert.IsNull(result.Model);
        }

        [TestMethod]
        public void DetailsWithResults()
        {
            _productClientMock.Setup(pc => pc.GetProduct(It.IsAny<long>()))
                .Returns(new ProductModel { ProductId = 1, Name = "Test 1", Description = "Test 1 Desc", Price = 10 });
            ViewResult result = _productController.Details(1) as ViewResult;
            var resultsModel = result.Model as ProductViewModel;
            Assert.IsNotNull(resultsModel);
            Assert.IsTrue(resultsModel.ProductId == 1);
        }
    }
}
