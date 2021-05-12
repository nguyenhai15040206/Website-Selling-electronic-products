using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestCreateAccount
    {
        IWebDriver driver;
        [TestInitialize]
        public void Oppen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:49812/NguoiDung/dangKy");
        }

        // Đúng
        [TestMethod]
        public void TestMethod_Name1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // sai 

        // trống họ tên
        [TestMethod]
        public void TestMethod_Name2()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // sai 

        // trống sđt
        [TestMethod]
        public void TestMethod_Phone1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // sai 

        // sai định dạng sđt
        [TestMethod]
        public void TestMethod_Phone2()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("03578668482");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        // sai 

        // sai định dạng sđt
        [TestMethod]
        public void TestMethod_Phone3()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("3578668482");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }
        // sai 

        // sai định dạng sđt
        [TestMethod]
        public void TestMethod_Phone4()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("03a78668482");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem2");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //sai
        
        // Trống gmail
        [TestMethod]
        public void TestMethod_Gmail1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //sai

        //sai định dạng gmail
        [TestMethod]
        public void TestMethod_Gmail2()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }




        //sai

        //trống tên đăng nhập
        [TestMethod]
        public void TestMethod_UserName1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //trùng tên đăng nhập
        [TestMethod]
        public void TestMethod_UserName5()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //sai

        //sai định dạng tên đăng nhập

        /// <summary>
        /// //còn sai
        /// </summary>
        [TestMethod]
        public void TestMethod_UserName2()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("dd");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //sai



        /// <summary>
        /// còn sai
        /// </summary>
        //sai định dạng tên đăng nhập
        [TestMethod]
        public void TestMethod_UserName3()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("ThuongemladieuanhkhongthengoiNooPhuocThinh");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        //sai


        /// <summary>
        /// còn sai
        /// </summary>
        //sai định dạng tên đăng nhập
        [TestMethod]
        public void TestMethod_UserName4()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("Kieu Diem");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //Trống mật khẩu
        [TestMethod]
        public void TestMethod_Pass1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("KieuDiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //sai mật khẩu<5
        [TestMethod]
        public void TestMethod_Pass2()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("KieuDiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("sa");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("sa");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //sai mật khẩu >30
        [TestMethod]
        public void TestMethod_Pass3()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("KieuDiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("ThuongemladieuanhkhongthengoiNooPhuocThinh");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("ThuongemladieuanhkhongthengoiNooPhuocThinh");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //có khoảng trắng
        [TestMethod]
        public void TestMethod_Pass4()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem 28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys(" kieudiem 28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
            Thread.Sleep(5000);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }


        //sai

        //Mật khẩu không trùng
        [TestMethod]
        public void TestMethod_RePass1()
        {
            driver.FindElement(By.Id("tenKhachHang")).SendKeys("Thái Trần Kiều Diễm");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("email")).SendKeys("kieudiem2801@gmail.com");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("soDienThoai")).SendKeys("0357866848");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("tenDangNhap")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("matKhau")).SendKeys("kieudiem28");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("reMatKhau")).SendKeys("kieudiem");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("diaChi")).SendKeys("11/29 Dương đức hiền, Phường Tây Thạnh, Quận Tân Phú");
            Thread.Sleep(1500);
            driver.FindElement(By.Id("btnDangKi")).Click();
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
