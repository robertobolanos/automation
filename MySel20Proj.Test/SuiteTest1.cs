using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MySel20Proj.Test
{
    [TestClass]
    public class SuiteTest1
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
            var page = new EtsyGallery(this.driver);
            page.GotoTreasuryGallery()
                .ChooseGallery();
        }
    }
}
