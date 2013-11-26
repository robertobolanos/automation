using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest2
    {

        private IWebDriver driver;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = new FirefoxDriver();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var page = new Suite2(this.driver);
            page.SearchForAnItem("hat")
                .BuySomething();
            string cart = page.Count();
            Assert.AreEqual("1", cart);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var page = new Suite2(this.driver);
            page.SearchForAnItem("hat")
                .BuySomething()
                .GotoCart()
                .ClearCart();
            var empty = page.GetEmptyCart();
            Assert.IsTrue(empty);
        }
    }
}
