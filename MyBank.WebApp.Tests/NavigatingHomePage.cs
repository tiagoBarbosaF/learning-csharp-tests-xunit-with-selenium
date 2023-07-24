using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using MyBank.WebApp.Tests.PageObjects;
using MyBank.WebApp.Tests.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;
using Xunit.Abstractions;

namespace MyBank.WebApp.Tests
{
    public class NavigatingHomePage : IClassFixture<Manager>
    {
        private static IWebDriver _driver;
        private HttpClient _httpClient = new();
        private ITestOutputHelper _outputHelper;
        private string _urlHome = "https://localhost:5001";
        private string _email = "andre@email.com";
        private string _password = "senha01";
        private LoginPO _loginPo;

        public NavigatingHomePage(ITestOutputHelper outputHelper, Manager manager)
        {
            _outputHelper = outputHelper;

            _driver = manager.Driver;
            
            _loginPo = new LoginPO(_driver);
        }
        

        [Fact(DisplayName = "Load Home Page and check page title")]
        public void LoadHomePageAndCheckPageTitle()
        {
            _loginPo.Navigate(_urlHome);

            Assert.Contains("WebApp", _driver.Title);
        }

        [Fact(DisplayName = "Load Home Page and check if exist link login and home")]
        public void LoadHomePageAndCheckIfExistLinkLoginAndHome()
        {
            _loginPo.Navigate(_urlHome);

            Assert.Contains("Login", _driver.PageSource);

            Assert.Contains("Home", _driver.PageSource);
        }

        [Fact(DisplayName = "Login WebApp MyBank")]
        public void LoginWebAppMyBank()
        {
            _loginPo.ToFillInLoginFields(_urlHome, _email, _password);
        }

        [Fact(DisplayName = "Valid login link in home page")]
        public void ValidLoginLinkHomePage()
        {
            _loginPo.Navigate(_urlHome);

            var loginLink = _driver.FindElement(By.LinkText("Login"));

            loginLink.Click();

            Assert.Contains("img", _driver.PageSource);
        }

        [Fact(DisplayName = "After login check if exists the menu options Agencia")]
        public void AfterLoginCheckMenuAgencia()
        {
            _loginPo.ToFillInLoginFields(_urlHome, _email, _password);

            Assert.Contains("Agência", _driver.PageSource);
        }

        [Fact(DisplayName = "Check login fields required")]
        public void CheckLoginFieldsRequired()
        {
            _loginPo.Navigate(_urlHome);

            _driver.FindElement(By.LinkText("Login")).Click();

            _driver.FindElement(By.Id("btn-logar")).Click();

            Assert.Contains("The Email field is required.", _driver.PageSource);

            Assert.Contains("The Senha field is required", _driver.PageSource);
        }

        [Fact(DisplayName = "Check login password wrong")]
        public void CheckLoginPasswordWrong()
        {
            _loginPo.ToFillInLoginFields($"{_urlHome}/UsuarioApps/Login", _email, "111");

            Assert.Contains("Exception: Invalid Password.", _driver.PageSource);
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

        [Fact(DisplayName = "Check record a client")]
        public void CheckRecordClient()
        {
            _loginPo.ToFillInLoginFields(_urlHome, _email, _password);

            _driver.Navigate().GoToUrl($"{_urlHome}/Clientes/Index");

            _driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            _driver.FindElement(By.Id("Identificador")).Click();

            _driver.FindElement(By.Id("Identificador")).SendKeys(Guid.NewGuid().ToString());

            _driver.FindElement(By.Id("CPF")).Click();

            _driver.FindElement(By.Id("CPF")).SendKeys("194.089.110-83");

            _driver.FindElement(By.Id("Nome")).Click();

            _driver.FindElement(By.Id("Nome")).SendKeys("John Snow");

            _driver.FindElement(By.Id("Profissao")).Click();

            _driver.FindElement(By.Id("Profissao")).SendKeys("Vigilante");

            _driver.FindElement(By.CssSelector(".btn-primary")).Click();

            Assert.Contains("Logout", _driver.PageSource);
        }

        [Fact(DisplayName = "Check list of Contas")]
        public void CheckListOfContas()
        {
            var conta = "4159";

            _loginPo.ToFillInLoginFields(_urlHome, _email, _password);

            _driver.FindElement(By.Id("contacorrente")).Click();

            var elements = _driver.FindElements(By.TagName("td"));

            // foreach (var element in elements) _outputHelper.WriteLine(element.Text);
            var element = (from webElement in elements
                where webElement.Text.Contains(conta)
                select webElement).First();

            Assert.Equal(conta, element.Text);
        }
    }
}