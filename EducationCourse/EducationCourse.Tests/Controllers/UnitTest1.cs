using EducationCourse.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;

namespace EducationCourse.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
            [TestMethod]
            public void IndexViewResultNotNull()
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.Contact() as ViewResult;

                Assert.IsNotNull(result);
            }


            [TestMethod]
            public void IndexViewEqualIndexCshtml()
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.About() as ViewResult;

                Assert.AreEqual("About", result.ViewName);
            }


            [TestMethod]
            public void IndexStringInViewbag()
            {
                HomeController controller = new HomeController();

                ViewResult result = controller.About() as ViewResult;

                Assert.AreEqual("About", result.ViewName);
            }
    }
}
