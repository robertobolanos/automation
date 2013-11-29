using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySel20Proj
{
    public class Suite3 : LoadableComponent<Suite3>
    {
        private IWebDriver driver;       

        public Suite3(IWebDriver driver)
        {
            this.driver = driver;
        }

        public Suite3 SelectSubCategory(string category)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var suggestions = wait.Until<IWebElement>(x => { return x.FindElement(By.Id("search-suggestions")); });

            var element = suggestions.FindElement(By.XPath("//li[@data-search-type='" + category + "']"));
            element.Click();

            return this;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains("www.etsy.com");
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }
    }
}
