using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace MyBank.WebApp.Tests
{
    public class NavigatingHomePage
    {
        private readonly FirefoxDriver _driver =
            new(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + $"\\Debug\\net5.0"));

        [Fact(DisplayName = "Load Home Page and check page title")]
        public void LoadHomePageAndCheckPageTitle()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            Assert.Contains("WebApp", _driver.Title);
        }

        [Fact(DisplayName = "Load Home Page and check if exist link login and home")]
        public void LoadHomePageAndCheckIfExistLinkLoginAndHome()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            Assert.Contains("Login", _driver.PageSource);

            Assert.Contains("Home", _driver.PageSource);
        }

        [Fact(DisplayName = "Login WebApp MyBank")]
        public void LoginWebAppMyBank()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            _driver.Manage().Window.Size = new System.Drawing.Size(2576, 1408);

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");

            _driver.FindElement(By.Id("Senha")).Click();

            _driver.FindElement(By.Id("Senha")).SendKeys("senha01");

            _driver.FindElement(By.Id("btn-logar")).Click();

            _driver.FindElement(By.CssSelector(".btn")).Click();
        }
    }
}