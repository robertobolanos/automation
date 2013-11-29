using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest2
    {

        private IWebDriver driver;

        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

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
        [DeploymentItem("SuiteTestData2.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "SuiteTestData2.xml",
                   "Test1",
                    DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            var item = (string)context.DataRow["item"];
            var expected = (string)context.DataRow["expected"];
            var page = PageFactory.InitElements<EtsyHomePage>(driver)
                .Load()
                .SearchForAnItem(item);
            page.BuySomething();
            string cart = page.GotoCart().Count();
            Assert.AreEqual(expected, cart);
        }

        [TestMethod]
        [DeploymentItem("SuiteTestData2.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "SuiteTestData2.xml",
                   "Test2",
                    DataAccessMethod.Sequential)]
        public void TestMethod2()
        {
            var item = (string)context.DataRow["item"];
            var page = PageFactory.InitElements<EtsyHomePage>(driver)
                .Load()
                .SearchForAnItem(item);
            page.BuySomething()
                .GotoCart()
                .ClearCart();
            var empty = page.GotoCart().GetEmptyCart();
            Assert.IsTrue(empty);
        }
    }
}
