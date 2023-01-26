using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonProj;
using OpenQA.Selenium;
namespace AmazonProj
{
    public class Item
    {
        private string title;
        private string price;
        private string url;
        public Item(string title, string price, string url)
        {
            this.title = title;
            this.price = price;
            this.url = url;
        }
        public string Title{
            get { return title; }
            set { title = value; }
        }
        public string Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        public string toString()
        {
            return title + " " + price + " " + url;
        }
    }
}
