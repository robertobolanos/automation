using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MySel20Proj
{
    public class ResultSearch : LoadableComponent<ResultSearch>
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "listing-thumb")]
        private IList<IWebElement> gallery;

        [FindsBy(How = How.ClassName, Using = "btn-transaction")]
        private IWebElement buttonTransaction;

        [FindsBy(How = How.Id, Using = "cart_ref")]
        private IWebElement cart;

        public ResultSearch(IWebDriver driver)
        {
            this.driver = driver;
        }        

        public ResultSearch BuySomething()
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

        public Cart GotoCart()
        {
            cart.Click();
            return PageFactory.InitElements<Cart>(driver); ;
        }

        public ResultSearch SelectSubCategory(string category)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var suggestions = wait.Until<IWebElement>(x => { return x.FindElement(By.Id("search-suggestions")); });

            var element = suggestions.FindElement(By.XPath("//li[@data-search-type='" + category + "']"));
            element.Click();

            return this;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains("search");
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }
    }
}
