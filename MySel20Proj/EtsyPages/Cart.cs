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
    public class Cart : LoadableComponent<ResultSearch>
    {

        private IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "div.count")]
        private IWebElement count;        

        [FindsBy(How = How.ClassName, Using = "button-remove")]
        private IList<IWebElement> buttonsRemove;

        public Cart(IWebDriver driver)
        {
            this.driver = driver;
        }        

        public Cart ClearCart()
        {
            foreach (var item in buttonsRemove)
            {
                item.Click();
            }
            return this;
        }

        public bool GetEmptyCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until<IWebElement>(x => { return x.FindElement(By.Id("newempty")); });

            var text = driver.FindElement(By.CssSelector("#newempty")).Text;
            return Regex.IsMatch(text, "^[\\s\\S]*Your cart is empty.[\\s\\S]*$");
        }

        public string Count()
        {
            return count.Text;
        }

        protected override bool EvaluateLoadedStatus()
        {
            return driver.Url.Contains("ref=so_cart");
        }

        protected override void ExecuteLoad()
        {
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }
    }
}
