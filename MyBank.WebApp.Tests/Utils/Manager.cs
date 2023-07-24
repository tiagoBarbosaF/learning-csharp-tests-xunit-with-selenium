using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MyBank.WebApp.Tests.Utils
{
    public class Manager : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public Manager()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");
            
            Driver = new FirefoxDriver(Util.PathDriverFirefox(), firefoxOptions);
        }

        public void Dispose() => Driver.Quit();
    }
}