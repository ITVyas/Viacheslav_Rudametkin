using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Specs.Drivers
{
    public class BrowserDriver
    {
        public IWebDriver Driver { get; }
        private string _url;
        static private BrowserDriver _instance = null;

        private BrowserDriver()
        {
            _url = null;
            Driver = new ChromeDriver("../ChromeDriver");
        }

        static public BrowserDriver GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BrowserDriver();
            }    
            return _instance;
        }

        public IWebDriver NavigateToUrl(in string url)
        {
            _url = (string)url.Clone();
            Driver.Navigate().GoToUrl(url);
            return Driver;
        }
    }
}