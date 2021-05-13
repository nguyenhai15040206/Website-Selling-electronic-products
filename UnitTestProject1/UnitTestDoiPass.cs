using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestDoiPass
    {
        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/dangNhap");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("nameTTTK")).Clear();
            driver.FindElement(By.Id("nameTTTK")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("037831826d");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("3783182689");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("phone")).Clear();
            driver.FindElement(By.Id("phone")).SendKeys("01783182689");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //Sai 
        /// <summary>
        /// 
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("email")).Clear();
            driver.FindElement(By.Id("email")).SendKeys("thaikieudiemgmal.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
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
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            driver.FindElement(By.Id("address")).Clear();
            driver.FindElement(By.Id("address")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //sai
        /// <summary>
        ///
        /// </summary>
        //Để trống mật khẩu
        [TestMethod]
        public void TestMethod_OldPass()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);

            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //sai
        /// <summary>
        ///
        /// </summary>
        //Để sai mật khẩu
        [TestMethod]
        public void TestMethod_OldPass1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);

            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai1234");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("newPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //sai
        /// <summary>
        ///
        /// </summary>
        //Để trống new pass
        [TestMethod]
        public void TestMethod_NewPass()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);

            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai1234");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("newPass")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }

        //sai
        /// <summary>
        ///
        /// </summary>
        //Repass không trùng
        [TestMethod]
        public void TestMethod_NewPass1()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);

            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).Clear();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("newPass")).SendKeys("12345");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("123456");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnCN")).Click();
            Thread.Sleep(5000);
        }


        //đúng
        [TestMethod]
        public void TestMethod_TC()
        {
            driver.FindElement(By.Id("TenDangNhap")).SendKeys("hainguyen");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("MatKhau")).SendKeys("tanhai123");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btn")).Click();
            Thread.Sleep(1500);
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/thongTinTaiKhoan?maKhachHang=2");
            Thread.Sleep(1500);

            driver.FindElement(By.Id("action")).Click();
            Thread.Sleep(1500);
            driver.FindElement(By.Id("oldPass")).SendKeys("tanhai123");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("newPass")).SendKeys("tanhai1234");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reNewPass")).SendKeys("tanhai1234");
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
