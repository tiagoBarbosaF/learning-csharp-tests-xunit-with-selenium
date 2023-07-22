using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace MyBank.WebApp.Tests
{
    public class NavigatingHomePage
    {
        private IWebDriver _driver;

        private HttpClient _httpClient = new();

        public NavigatingHomePage()
        {
            var firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--headless");

            _driver = new FirefoxDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location + $"\\Debug\\net5.0"), firefoxOptions);
        }

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

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");

            _driver.FindElement(By.Id("Senha")).Click();

            _driver.FindElement(By.Id("Senha")).SendKeys("senha01");

            _driver.FindElement(By.Id("btn-logar")).Click();

            _driver.FindElement(By.CssSelector(".btn")).Click();
        }

        [Fact(DisplayName = "Valid login link in home page")]
        public void ValidLoginLinkHomePage()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            var loginLink = _driver.FindElement(By.LinkText("Login"));

            loginLink.Click();

            Assert.Contains("img", _driver.PageSource);
        }

        [Fact(DisplayName = "After login check if exists the menu options Agencia")]
        public void AfterLoginCheckMenuAgencia()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");

            _driver.FindElement(By.Id("Senha")).Click();

            _driver.FindElement(By.Id("Senha")).SendKeys("senha01");

            _driver.FindElement(By.Id("btn-logar")).Click();

            Assert.Contains("Agência", _driver.PageSource);
        }

        [Fact(DisplayName = "Check login fields required")]
        public void CheckLoginFieldsRequired()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("btn-logar")).Click();

            Assert.Contains("The Email field is required.", _driver.PageSource);

            Assert.Contains("The Senha field is required", _driver.PageSource);
        }

        [Fact(DisplayName = "Check login password wrong")]
        public void CheckLoginPasswordWrong()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001");

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("Email")).Click();

            _driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");

            _driver.FindElement(By.Id("Senha")).Click();

            _driver.FindElement(By.Id("Senha")).SendKeys("1111");

            _driver.FindElement(By.Id("btn-logar")).Click();

            Assert.Contains("Exception: Invalid Password", _driver.PageSource);
        }

        [Fact(DisplayName = "Check url access menu Agência")]
        public void CheckUrlAccessMenuAgencia()
        {
            var response = _httpClient.GetAsync("https://localhost:5001/Agencia/Index").GetAwaiter().GetResult();

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "Check url access menu Cliente")]
        public void CheckUrlAccessMenuCliente()
        {
            var response = _httpClient.GetAsync("https://localhost:5001/Clientes/Index").GetAwaiter().GetResult();
            
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact(DisplayName = "Check url access menu Conta Corrente")]
        public void CheckUrlAccessMenuContaCorrente()
        {
            var response = _httpClient.GetAsync("https://localhost:5001/ContaCorrentes/Index").GetAwaiter().GetResult();
            
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}