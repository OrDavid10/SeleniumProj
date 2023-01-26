using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;
namespace AmazonProj
{
    public class Results
    {
        private IWebDriver driver;
        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }
        //This function gets a dictionary as parameter and filters the web elements by the dictionary values with xpath queries,
        //And then creates a list of filtered items that matches the conditions and prints it .
        public List<Item> GetResultsBy(Dictionary<string, string> filters)
        {
            List<Item> results = new List<Item>();
            string xpath = "(//span[@class='a-price' ";
            string endXpath = "]//ancestor::div[@class='a-section a-spacing-small a-spacing-top-small'])";
            //Adding the web elements to the xpath if the conditions are exists
            foreach (string key in filters.Keys) {
                switch (key)
                {
                    case "price lower then":
                        xpath += $" and number(substring-before(substring((.), 2, 30), '$')) < {filters["price lower then"]}";
                        break;
                    case "price higher or equal":
                        xpath += $" and number(substring-before(substring((.), 2, 30), '$')) >= {filters["price higher or equal"]} ";
                        break;
                    case "free shipping":
                        if (filters[key].Equals("true"))
                        {
                            xpath += " and .//ancestor::div[@class='sg-row' and .//span[contains(text(), 'FREE Shipping')]] ";
                        }
                        else
                        {
                            xpath += " and .//ancestor::div[@class='sg-row' and .//span[not(contains(text(), 'FREE Shipping'))]] ";
                        }
                        break;
                    default:
                        return null;
                }
            }
            //Unite both pathes
            xpath += endXpath;
            //Creation of a list of web elements that each one in it matches to the conditions after filtering
            IList<IWebElement> items = driver.FindElements(By.XPath(xpath));
            //Iteration on each web element and cast its values to text , than creation of an item from its casted values 
            for (int i = 0; i < items.Count; i++)
            {
                IWebElement aElement = driver.FindElement(By.XPath($"{xpath}[{i + 1}]//a[@class='a-size-base a-link-normal s-underline-text s-underline-link-text s-link-style a-text-normal']"));
                string title = driver.FindElement(By.XPath($"{xpath}[{i + 1}]//span[@class='a-size-medium a-color-base a-text-normal']")).Text;
                string price = driver.FindElement(By.XPath($"{xpath}[{i + 1}]//span[@class='a-price-whole']")).Text;
                string priceFraction = driver.FindElement(By.XPath($"{xpath}[{i + 1}]//span[@class='a-price-fraction']")).Text;
                string url = aElement.GetAttribute("href");
                string fullPrice = price + '.' + priceFraction +'$';
                //Adding each item to the list and prints the results to test explorer console.
                results.Add(new Item(title, fullPrice, url));
                Console.WriteLine($"Item {i + 1}:" + results[i].toString());               
            }
            return results;
        }
    }
}

