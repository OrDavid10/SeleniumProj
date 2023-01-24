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
    public class UnitTest2
    {
        public static IWebDriver driver;
        [SetUp]
        public void startBrowser()
        {
            ChromeOptions options = new ChromeOptions();
           // FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("start-maximized");
            driver = new ChromeDriver("C:\\Drivers\\Chrome\\", options);
           // driver = new FirefoxDriver("C:\\Drivers\\Firefox\\");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Test]
         public void test()
         {
          driver.Navigate().GoToUrl("https://www.amazon.com");
          Amazon Amazon = new Amazon(new ChromeDriver());
          Amazon.Pages.Home.SearchBar.Text="mouse";
          Amazon.Pages.Home.SearchBar.Click();
         //Amazon.Pages.Results.GetResultsBy();
        }
        [TearDown]
        public void closeBrowser()
        {
            // driver.Close();
        }
    }
}
