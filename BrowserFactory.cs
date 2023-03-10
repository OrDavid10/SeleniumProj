using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Edge;
using AmazonProj;
namespace AmazonProj
{
    class BrowserFactory
    {      
        private static IDictionary<string, IWebDriver> drivers = new Dictionary<string, IWebDriver>();
        private static IWebDriver driver;
        public IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }
        public IDictionary<string, IWebDriver> Drivers
        {
            get
            {
                return drivers;
            }
            private set
            {
                drivers = value;
            }
        }      
        public static IWebDriver GetDriver(string browserName, List<string> options)
        {
            switch (browserName.ToLower())
            {
                case "firefox":
                    if (!drivers.ContainsKey("firefox"))
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments(options);
                        try
                        {
                            IWebDriver fireFoxDriver = new FirefoxDriver("C:\\Drivers\\Firefox\\", firefoxOptions);
                            drivers.Add("firefox", fireFoxDriver);
                            return fireFoxDriver;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The firefox driver didn't start, did you put the right options?", ex.Message);
                        }
                    }
                    break;
                case "edge":
                    if (!drivers.ContainsKey("edge"))
                    {
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments(options);
                        try
                        {
                            IWebDriver edgeDriver = new EdgeDriver("C:\\Drivers\\Edge\\", edgeOptions);
                            drivers.Add("edge", edgeDriver);
                            return edgeDriver;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The edge driver didn't start, did you put the right options?", ex.Message);
                        }
                    }
                    break;
                case "chrome":
                default:
                    if (!drivers.ContainsKey("chrome"))
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments(options);
                        try
                        {
                            IWebDriver chromeDriver = new ChromeDriver("C:\\Drivers\\Chrome\\", chromeOptions);
                            drivers.Add("chrome", chromeDriver);
                            return chromeDriver;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("The chrome driver didn't start, did you put the right options?", ex.Message);
                        }
                    }
                    break;
            }
            return null;
        }
        public static void LoadApplication(string url, IWebDriver driver)
        {
            driver.Url = url;
        }
        public static void CloseDriver(IWebDriver driver)
        {
            driver.Close();
        }       
    }
}

