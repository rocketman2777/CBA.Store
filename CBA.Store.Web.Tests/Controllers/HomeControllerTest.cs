using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CBA.Store.Web;
using CBA.Store.Web.Controllers;

namespace CBA.Store.Web.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private HomeController _homeController;

        [TestInitialize]
        public void SetupForTest()
        {
            _homeController = new HomeController();
        }

        [TestMethod]
        public void Index()
        {
            ViewResult result = _homeController.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
