using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySel20Proj
{
    public class EtsyHomePage : LoadableComponent<EtsyHomePage>
    {
        private IWebDriver driver;

        [FindsBy(How = How.Name)]
        private IWebElement search_query;

        [FindsBy(How = How.Name)]
        private IWebElement search_submit;        

        public EtsyHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public GalleryPage GotoGallery(string gallery)
        {
            search_query.SendKeys(gallery);
            search_submit.Submit();
            return PageFactory.InitElements<GalleryPage>(driver);
        }

        public ResultSearch SearchForAnItem(string item)
        {
            search_query.SendKeys(item);
            search_submit.Submit();
            return PageFactory.InitElements<ResultSearch>(driver);
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

