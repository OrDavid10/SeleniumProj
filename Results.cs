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
        IReadOnlyList<IWebElement> items;
        private Dictionary<string, string> filter = new Dictionary<string, string>();
        //private string xpath = "$x("//span[@class='a-price' and translate(descendant::span[@class='a-offscreen']//.,'$','')]")";
        public Dictionary<string, string> Filter
        {
            get { return this.filter; }
            set { this.filter = value; }
        }
        public Results(IWebDriver driver)
        {
            this.driver = driver;
        }
        enum DictionaryKeys
        {
            price_lower_then,
            price_higher_or_equal,
            free_shipping
        }
      /*  public List<Item> GetResultsBy(Dictionary<string,string>filters )
        {
            string xpath = "$x(\"//span[@class='a-price' and translate(descendant::span[@class='a-offscreen']//.,'$','')]\")";
            foreach (KeyValuePair<string,string> filter in filters)
            {
                switch (filter.Key)
                {
                    case DictionaryKeys.price_lower_then.ToString():
                        xpath = filter.Value;
                        break;
                    case DictionaryKeys.price_higher_or_equal.ToString():
                        xpath = filter.Value;
                        break;
                    case DictionaryKeys.free_shipping.ToString():
                        xpath = filter.Value;
                        break;
                }
            }
        }*/
    }
}
