using OpenQA.Selenium;

namespace MyBank.WebApp.Tests.PageObjects
{
    public class LoginPO
    {
        private IWebDriver _driver;
        private By _fieldEmail;
        private By _fieldPassword;
        private By _btnLogar;

        public LoginPO(IWebDriver driver)
        {
            _driver = driver;
            _fieldEmail = By.Id("Email");
            _fieldPassword = By.Id("Senha");
            _btnLogar = By.Id("btn-logar");
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ToFillInLoginFields(string url, string email, string password)
        {
            Navigate(url);
            
            _driver.FindElement(By.LinkText("Login")).Click();
            
            _driver.FindElement(_fieldEmail).Click();
            
            _driver.FindElement(_fieldEmail).SendKeys(email);
            
            _driver.FindElement(_fieldPassword).Click();
            
            _driver.FindElement(_fieldPassword).SendKeys(password);
            
            _driver.FindElement(_btnLogar).Click();
        }
    }
}