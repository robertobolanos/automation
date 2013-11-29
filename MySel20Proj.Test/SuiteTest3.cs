using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;

namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest3
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
        [DeploymentItem("SuiteTestData3.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "SuiteTestData1.xml",
                   "Test3",
                    DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            var item = (string)context.DataRow["item"];
            var category = (string)context.DataRow["category"];
            var page = PageFactory.InitElements<EtsyHomePage>(driver)
                .Load()
                .SearchForAnItem(item);
            page.SelectSubCategory(category);

        }

        [TestMethod]
        [DeploymentItem("SuiteTestData3.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "SuiteTestData3.xml",
                   "Test2",
                    DataAccessMethod.Sequential)]
        public void TestMethod2()
        {
            var item = (string)context.DataRow["item"];
            var category = (string)context.DataRow["category"];
            var page = PageFactory.InitElements<EtsyHomePage>(driver)
                .Load()
                .SearchForAnItem(item);
            page.SelectSubCategory(category);

        }
    }
}
