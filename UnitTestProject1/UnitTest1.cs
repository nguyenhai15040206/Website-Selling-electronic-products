using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/dangNhap");
            driver.Manage().Window.Maximize();
        }
        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            driver.FindElement(By.Id("btn")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
    }
}
