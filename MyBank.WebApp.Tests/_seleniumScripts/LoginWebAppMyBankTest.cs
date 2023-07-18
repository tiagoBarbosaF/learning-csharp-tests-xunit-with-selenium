using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

public class SuiteTests : IDisposable
{
    public IWebDriver driver { get; private set; }
    public IDictionary<String, Object> vars { get; private set; }
    public IJavaScriptExecutor js { get; private set; }

    public SuiteTests()
    {
        driver = new FirefoxDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<String, Object>();
    }

    public void Dispose()
    {
        driver.Quit();
    }

    [Fact]
    public void LoginWebAppMyBank()
    {
        driver.Navigate().GoToUrl("https://localhost:5001/");
        driver.Manage().Window.Size = new System.Drawing.Size(2576, 1408);
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("Email")).Click();
        driver.FindElement(By.Id("Email")).Click();
        driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
        driver.FindElement(By.Id("Senha")).Click();
        driver.FindElement(By.Id("Senha")).SendKeys("senha01");
        driver.FindElement(By.Id("btn-logar")).Click();
        driver.FindElement(By.CssSelector(".btn")).Click();
    }
}