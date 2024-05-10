using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRUD_application_2.Controllers;
using System.Web.Mvc;
using CRUD_application_2.Models;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UserNUnit
{
    [TestClass]
    public class UserControllerTests
    {
        private UserController controller;

        [TestInitialize]
        public void Setup()
        {
            controller = new UserController();
        }

        [TestMethod]
        public void Index()
        {
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Details_ValidId()
        {
            var result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Details_InvalidId()
        {
            var result = controller.Details(100);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Create_Get()
        {
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create_Post_ValidModel()
        {
            var user = new User { Id = 11, Name = "User11", Email = "user11@example.com" };
            var result = controller.Create(user) as HttpStatusCodeResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(201, result.StatusCode);
        }

        [TestMethod]
        public void Edit_Get_ValidId()
        {
            var result = controller.Edit(1) as ViewResult;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Edit_Get_InvalidId()
        {
            var result = controller.Edit(100);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Edit_Post_ValidModel()
        {
            var user = new User { Id = 1, Name = "User1", Email = "user1@example.com" };
            var result = controller.Edit(1, user) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            //Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Delete_Get_ValidId()
        {
            var result = controller.Delete(1) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            //Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Delete_Get_InvalidId()
        {
            var result = controller.Delete(100);
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }

        [TestMethod]
        public void Delete_Post_ValidId()
        {
            var result = controller.Delete(1, new FormCollection()) as RedirectToRouteResult;
            Assert.IsNotNull(result);
            //Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void Delete_Post_InvalidId()
        {
            var result = controller.Delete(100, new FormCollection());
            Assert.IsInstanceOfType(result, typeof(HttpNotFoundResult));
        }
    }
}
