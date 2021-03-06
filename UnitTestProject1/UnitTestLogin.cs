using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestLogin
    {
        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/dangNhap");
        }

        // Đúng
        [TestMethod]
        public void TestMethod_TC()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // test tên đăng nhập và mật khẩu không được bỏ trống
        [TestMethod]
        public void TestMethod_NULL()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // test tên đăng nhập không được bỏ trống
        [TestMethod]
        public void TestMethod_UserName()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // test mật khẩu không được bỏ trống
        [TestMethod]
        public void TestMethod_Pass()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // sai tên đăng nhập
        [TestMethod]
        public void TestMethod_Name1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen1");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // sai mật khẩu
        [TestMethod]
        public void TestMethod_Pass1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        [TestCleanup]
        public void Closed()
        {
            driver.Quit();
        }
    }
}
