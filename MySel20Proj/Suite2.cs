using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MySel20Proj
{
    public class Suite2
    {
        private IWebDriver driver;

        public Suite2(IWebDriver driver)
        {
            this.driver = driver;
            driver.Navigate().GoToUrl("http://www.etsy.com");
        }

        public Suite2 SearchForAnItem(string item)
        {
            IWebElement query = driver.FindElement(By.Name("search_query"));
            query.SendKeys(item);

            IWebElement button = driver.FindElement(By.Name("search_submit"));
            button.Submit();
            return this;
        }

        public Suite2 BuySomething()
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

        public Suite2 GotoCart()
        {
            driver.FindElement(By.Id("cart_ref")).Click();
            return this;
        }

        public Suite2 ClearCart()
        {
            var cart = driver.FindElements(By.ClassName("button-remove"));
            foreach (var item in cart)
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
            var Count = driver.FindElement(By.CssSelector("div.count"));
            return Count.Text;
        }

    }
}
