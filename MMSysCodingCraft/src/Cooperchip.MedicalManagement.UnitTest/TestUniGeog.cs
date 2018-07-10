using Cooperchip.MedicalManagement.Infra.Data;
using Cooperchip.MedicalManagement.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace Cooperchip.MedicalManagement.UnitTest
{
    [TestClass]
    public class TestUniGeog : Controller
    {
        private MedicalManagementDbContext db = new MedicalManagementDbContext();
        private UniGeogController _controller;

        [TestInitialize]
        public void SetUp()
        {
            _controller = new UniGeogController();
        }

        //[TestMethod]
        //public async Task DetalheUniGeogAsync()
        //{
        //    var result = await _controller.Details(100) as ViewResult;
        //    var unigeog = (UnidadeGeografica)result.Model;
        //    Assert.AreEqual("01012-030", unigeog.Cep);
        //    //Assert.IsNotNull(unigeog.Cep);
        //}

        [TestMethod]
        public void Soma()
        {
            Assert.AreEqual(9, _controller.Soma(2, 7));
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            _controller = null;
        }

    }

}


//var controller = new ProductController();
//var result = controller.Details(2) as ViewResult;
//var product = (Product)result.ViewData.Model;
//Assert.AreEqual("Laptop", product.Name);
