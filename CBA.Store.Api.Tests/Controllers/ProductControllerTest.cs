using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CBA.Store.Data.Interface;
using CBA.Store.Domain;
using CBA.Store.Api.Models;
using CBA.Store.Api.Mapping;
using CBA.Store.Api.Controllers;

namespace CBA.Store.Api.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        private ProductController _productController;
        private Mock<IProductRepository> _productRepositoryMock;

        [TestInitialize]
        public void SetupForTest()
        {
            // best to start with fresh objects for each test to avoid tests impacting each other
            _productRepositoryMock = new Mock<IProductRepository>();
            _productController = new ProductController(_productRepositoryMock.Object, MapperFactory.CreateMapper());
        }

        [TestMethod]
        public void ListingNoResults()
        {
            _productRepositoryMock.Setup(pr => pr.GetAll()).Returns(new List<Product>());
            var result = _productController.Get();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 0);
        }

        [TestMethod]
        public void ListingWithResults()
        {
            var results = new List<Product>()
            {
                new Product {  ProductId = 1, Name = "Test 1", Description = "Test 1 Desc", Price = 10 },
                new Product {  ProductId = 2, Name = "Test 2", Description = "Test 2 Desc", Price = 20 }
            };
            _productRepositoryMock.Setup(pr => pr.GetAll()).Returns(results);
            var result = _productController.Get();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0].ProductId == 1);
            Assert.IsTrue(result[1].ProductId == 2);
        }

        [TestMethod]
        public void DetailsNoResults()
        {
            _productRepositoryMock.Setup(pr => pr.Get(It.IsAny<long>())).Returns((Product)null);
            var result = _productController.Get(1);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DetailsWithResults()
        {
            _productRepositoryMock.Setup(pr => pr.Get(It.IsAny<long>()))
                .Returns(new Product { ProductId = 1, Name = "Test 1", Description = "Test 1 Desc", Price = 10 });
            var result = _productController.Get(1);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.ProductId == 1);
        }
    }
}
