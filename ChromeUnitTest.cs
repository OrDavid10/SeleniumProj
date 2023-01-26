using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using AmazonProj;
namespace AmazonProj
{
    public class ChromeUnitTest
    {
        public static IWebDriver driver;
        Dictionary<string,string> filter;
        Amazon Amazon;
        [SetUp]
        public void startBrowser()
        {
            driver = BrowserFactory.GetDriver("chrome",new List<string> {});
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            filter = new Dictionary<string, string>();
            filter["price lower then"] = "100";
            filter["price higher or equal"] = "50";
            filter["free shipping"] = "true";
        }
        [Test]
        public void test()
        {
          driver.Navigate().GoToUrl("https://www.amazon.com");
          Amazon = new Amazon(driver);
          Amazon.Pages.Home.SearchBar.Text= "mouse";
          Amazon.Pages.Home.SearchBar.Click();
          Amazon.Pages.Results.GetResultsBy(filter);
          Assert.Pass();
        }
        [TearDown]
        public void closeBrowser()
        {
            // driver.Close();
        }
    }
}
