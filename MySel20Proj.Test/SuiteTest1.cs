using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.PageObjects;


namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest1
    {
        
        private TestContext context;

        public TestContext TestContext
        {
            get { return context; }
            set { context = value; }
        }

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
        [DeploymentItem("SuiteTestData1.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                   "SuiteTestData1.xml",
                   "Row",
                    DataAccessMethod.Sequential)]
        public void TestMethod1()
        {
            var gallery = (string)context.DataRow["gallery"];
            var items = int.Parse((string)context.DataRow["items"]);
            var page = PageFactory.InitElements<EtsyHomePage>(driver).Load();
            page.GotoGallery(gallery)
                .NavigeteItems(items)
                .ChooseGallery();
        }
    }
}
