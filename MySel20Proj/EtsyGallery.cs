using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySel20Proj
{
    public class EtsyGallery
    {
        private IWebDriver driver;

        public EtsyGallery(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }

        public EtsyGallery GotoTreasuryGallery()
        {
            IWebElement query = driver.FindElement(By.Name("search_query"));
            query.SendKeys("treasury");

            IWebElement button = driver.FindElement(By.Name("search_submit"));
            button.Submit();

            return this;
        }

        public EtsyGallery NavigeteItems()
        {
            var galleryCount = driver.FindElements(By.ClassName("listing-thumb")).Count();
            if (galleryCount > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    driver.FindElements(By.ClassName("listing-thumb"))[i].Click();
                    driver.Navigate().Back();
                }
            }
            return this;
        }

        public EtsyGallery BuySomething()
        {
            var gallery = driver.FindElements(By.ClassName("listing-thumb"));
            if (gallery.Count() > 0)
            {
                gallery[0].Click();
                var button = driver.FindElement(By.ClassName("btn-transaction"));
                button.Submit();
                driver.Navigate().Back();
                driver.Navigate().Back();
            }
            return this;
        }

        public EtsyGallery ChooseGallery()
        {
            var gallery = driver.FindElement(By.CssSelector(".heading"));
            gallery.Click();
            return this;
        }

    }
}

