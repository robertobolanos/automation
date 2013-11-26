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
    public class MySel20Proj
    {
        public static void Main()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.google.com");            

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Cheese!");
            query.Submit();

            System.Console.WriteLine("Page title is: " + driver.Title);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(x => { return driver.Title.ToLower().StartsWith("cheese!"); });
            System.Console.WriteLine("Page title is: " + driver.Title);


            driver.Quit();

            Console.ReadLine();

        }
    }
}
