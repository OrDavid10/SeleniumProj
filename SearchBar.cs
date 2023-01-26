using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;
using System.Xml.Linq;
namespace AmazonProj
{
    public class SearchBar
    {
        private IWebDriver driver;
        public SearchBar(IWebDriver driver)
        {
            this.driver = driver;
        }
        public string Text
        {
            get
            {
                var SearchBar = driver.FindElement(By.Id("twotabsearchtextbox"));
                return SearchBar.Text;
            }
            set
            {
                var SearchBar = driver.FindElement(By.Id("twotabsearchtextbox"));
                SearchBar.SendKeys(value);
            }
        }
        public void Click()
        {
            var SearchBar = driver.FindElement(By.Id("nav-search-submit-button"));
            SearchBar.Click();
        }
    }
}
