using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestDatHang
    {
        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:49812/");
        }

        //SAI tên để trống

        //khi chưa đăng nhập
        [TestMethod]
        public void TestMethod_Name()
        {
            driver.FindElement(By.Id("xemChiTiet")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnMuaNgay")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangNhap")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnHoanTatDH")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("tenKhachHang")).Clear();
            driver.FindElement(By.Id("tenKhachHang")).SendKeys(" ");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương Đức Hiền, Phạm Ngọc Thảo, Tân Phú, HCM");
            Thread.Sleep(5000);
        }


        //SAI số điện thoại

        //khi chưa đăng nhập
        [TestMethod]
        public void TestMethod_Phone()
        {
            driver.FindElement(By.Id("xemChiTiet")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnMuaNgay")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangNhap")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnHoanTatDH")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("soDienThoai")).Clear();
            driver.FindElement(By.Id("soDienThoai")).SendKeys("037831826N");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương Đức Hiền, Phạm Ngọc Thảo, Tân Phú, HCM");         
            Thread.Sleep(5000);
        }

        //SAI để trống sđt

        //khi chưa đăng nhập
        [TestMethod]
        public void TestMethod_Phone1()
        {
            driver.FindElement(By.Id("xemChiTiet")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnMuaNgay")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangNhap")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnHoanTatDH")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("soDienThoai")).Clear();
            driver.FindElement(By.Id("soDienThoai")).SendKeys("");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương Đức Hiền, Phạm Ngọc Thảo, Tân Phú, HCM");
            Thread.Sleep(5000);
        }

        //ĐÚNG

        //CHƯA ĐĂNG NHẬP
        [TestMethod]
        public void TestMethod_TC()
        {
            driver.FindElement(By.Id("xemChiTiet")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnMuaNgay")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangNhap")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnHoanTatDH")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương Đức Hiền, Phạm Ngọc Thảo, Tân Phú, HCM");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("btnDongY")).Click();
            Thread.Sleep(5000);
        }
        //sai

        //ĐĂNG NHẬP KHÔNG THÀNH CÔNG
        [TestMethod]
        public void TestMethod_TB()
        {
            driver.FindElement(By.Id("xemChiTiet")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnMuaNgay")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("imgGioHang")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangNhap")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai1234");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(5000);
        }


        [TestCleanup]
        public void Closed()
        {
            driver.Quit();
        }
    }
}
