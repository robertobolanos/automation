using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySel20Proj
{
    public class GalleryPage : LoadableComponent<EtsyHomePage>
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "listing-thumb")]
        private IList<IWebElement> gallery;

        [FindsBy(How = How.ClassName, Using = "btn-transaction")]
        private IWebElement buttonTransaction;

        [FindsBy(How = How.CssSelector, Using = ".heading")]
        private IWebElement heading;

        public GalleryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public GalleryPage NavigeteItems(int limit)
        {
            var galleryCount = gallery.Count();
            if (galleryCount > limit)
            {
                for (int i = 0; i < limit; i++)
                {
                    gallery[i].Click();
                    driver.Navigate().Back();
                }
            }
            return this;
        }

        public GalleryPage BuySomething()
        {
            if (gallery.Count() > 0)
            {
                gallery.First().Click();
                buttonTransaction.Submit();
                driver.Navigate().Back();
                driver.Navigate().Back();
            }
            return this;
        }

        public GalleryPage ChooseGallery()
        {
            heading.Click();
            return this;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains("view_type=gallery");
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }
    }
}
