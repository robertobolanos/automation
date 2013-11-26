using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest3
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
                //driver.Quit();
            }
        }

        [TestMethod]
        public void TestMethod1()
        {
            var page = new Suite3(this.driver);
            page.SearchForAnItem("hat")
                .SelectSubCategory("category_tags_vintage");

        }

        [TestMethod]
        public void TestMethod2()
        {
            var page = new Suite3(this.driver);
            page.SearchForAnItem("ring")
                .SelectSubCategory("category_tags_jewelry.ring");

        }
    }
}
