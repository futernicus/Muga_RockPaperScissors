using Microsoft.VisualStudio.TestTools.UnitTesting;
using RockPaperScissors.Controllers;
using System.Web.Mvc;

namespace RockPaperScissors.Tests.Controllers
{
    [TestClass]
    // See RockPaperScissorsEngineTest for a more comprehensive and useful set of unit tests
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexRenders()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.About() as ViewResult;
            Assert.AreEqual("Minimal viable Rock,Paper,Scissors game", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Contact() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
