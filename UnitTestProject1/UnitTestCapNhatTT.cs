using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestCapNhatTT
    {


        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/dangNhap");
        }

        //Sai 

        //Để trống tên
        [TestMethod]
        public void TestMethod_Name()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("nameTTTK")).Clear();
            driver.FindElement(By.Id("nameTTTK")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //Sai 

        //Để trống số điện thoại
        [TestMethod]
        public void TestMethod_Phone()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //Sai 

        //Để sai định dạng sđt( có chữ cái)
        [TestMethod]
        public void TestMethod_Phone1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("037831826d");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //Sai 

        //Để sai định dạng sđt không có số 0
        [TestMethod]
        public void TestMethod_Phone2()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("3783182689");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //Sai 

        //Để sai định dạng sđt không phải 10 số
        [TestMethod]
        public void TestMethod_Phone3()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("01783182689");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //Sai 

        //Để trống email
        [TestMethod]
        public void TestMethod_Email()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //Sai 
        /// <summary>
        /// /Chưa ràng buộc
        /// </summary>
        //Để sai định dạng email
        [TestMethod]
        public void TestMethod_Email1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("thaikieudiemgmal.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //Sai 

        //Để trống địa chỉ
        [TestMethod]
        public void TestMethod_Address()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //Đúng

        //Cập nhật thành công
        [TestMethod]
        public void TestMethod_TC()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:8080/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("phone")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("phone")).SendKeys("0378318263");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("thaikieudiem@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("address")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("address")).SendKeys("11/29 Dương Đức Hiền,phường Tây Thạnh, quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        [TestCleanup]
        public void Closed()
        {
            driver.Quit();
        }
    }
}
