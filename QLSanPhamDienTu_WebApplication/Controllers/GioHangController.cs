using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLSanPhamDienTu_WebApplication.Models;

namespace QLSanPhamDienTu_WebApplication.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QLSanPhamDienTuDataContext db = new QLSanPhamDienTuDataContext();

        public List<GioHang> layGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                // nếu giỏ hàng chưa tồn tại thì khởi tạo giỏ hàng
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }

        // thêm sản phẩm vào giỏ hàng
        public ActionResult themSPVaoGioHang(int maSP, string strUrl)
        {
            // lấy ra giỏ hàng
            List<GioHang> listGioHang = layGioHang();

            // kiểm tra sản phẩm này có tồn tại trong Session["GioHang"] hay không?
            GioHang sanPham = listGioHang.Find(m => m.maSanPham == maSP);
            if (sanPham == null)
            {
                sanPham = new GioHang(maSP);
                listGioHang.Add(sanPham);
                return Redirect(strUrl);
            }
            else // đã có sản phẩm trong giỏ hàng
            {
                sanPham.soLuong++;
                return Redirect(strUrl);
            }
        }

        // tính tổng số lượng
        private int tongSoLuong()
        {
            int tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong = listGioHang.Sum(m => m.soLuong);
            }
            return tong;
        }

        // tính tổng thành tiền
        private double tongThanhTien()
        {
            double tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong += listGioHang.Sum(m => m.ThanhTien);
            }
            return tong;
        }

        // tổng giảm giá
        private double tongGiamGia()
        {
            double tong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tong += listGioHang.Sum(m => m.giamGia);
            }
            return tong;
        }

        // Xây dựng trang giỏ hàng
        public ActionResult trangGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("HttpNotFound_404", "HttpNotFound");
            }
            List<GioHang> listGioHang = layGioHang();
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongThanhTien = tongThanhTien();
            ViewBag.TongGiamGia = tongGiamGia();
            return View(listGioHang);
        }

        // giỏ hàng partial dữ lại số lượng mua mà không render tại trang
        public ActionResult gioHangPartial()
        {
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongThanhTien = tongThanhTien();
            ViewBag.TongGiamGia = tongGiamGia();
            return PartialView();
        }

        // cập nhật số lượng
        public ActionResult capNhatGioHang(int maSP, FormCollection f)
        {
            List<GioHang> listGioHang = layGioHang();
            GioHang sp = listGioHang.Single(m => m.maSanPham == maSP);
            if (sp != null)
            {
                sp.soLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("trangGioHang", "GioHang");
        }

        // xóa một sản phẩm trong giỏ hàng
        public ActionResult xoaSanPhamTrongGioHang_1Sp(int maSP)
        {
            List<GioHang> listGioHang = layGioHang();
            GioHang sp = listGioHang.Single(m => m.maSanPham == maSP);
            if (sp != null)
            {
                listGioHang.RemoveAll(m => m.maSanPham == maSP);
                if (listGioHang.Count == 0)
                {
                    return RedirectToAction("HttpNotFound_404", "HttpNotFound");
                }
                else
                {
                    return RedirectToAction("trangGioHang", "GioHang");
                }
            }
            return RedirectToAction("trangGioHang", "GioHang");
        }


        // tiến hành đặt hàng
        [HttpGet]
        public ActionResult datHang()
        {
            // kiểm tra session()
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("dangNhap", "NguoiDung");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("loadSanPhamDienThoai", "SanPham");
            }

            // lấy giở hang
            List<GioHang> listGIoHang = layGioHang();
            ViewBag.tinhTongSL = tongSoLuong();
            ViewBag.tinhTongThanhTien = tongThanhTien();
            return View();
        }


        [HttpPost]
        public ActionResult datHang(FormCollection f)
        {
            HoaDon hoaDon = new HoaDon();
            KhachHang kh = (KhachHang)Session["TaiKhoan"];
            List<GioHang> listGioHang = layGioHang();
            hoaDon.maKhachHang = kh.maKhachHang;
            hoaDon.ngayBan = DateTime.Now;
            hoaDon.ghiChu = "Chưa thanh toán";
            hoaDon.tienBan = (decimal)tongThanhTien();
            hoaDon.giamGia = 0;
            hoaDon.tongTien = (decimal)tongThanhTien();
            hoaDon.maNguoiDung = null;
            db.HoaDons.InsertOnSubmit(hoaDon);
            db.SubmitChanges();
            foreach (var item in listGioHang)
            {
                CTHoaDon ctHD = new CTHoaDon();
                ctHD.maHoaDon = hoaDon.maHoaDon;
                ctHD.maSanPham = item.maSanPham;
                ctHD.soLuong = item.soLuong;
                ctHD.donGia = (decimal)item.donGia;
                ctHD.giamGia = item.giamGia;
                ctHD.thanhTien = (decimal)item.ThanhTien;
                db.CTHoaDons.InsertOnSubmit(ctHD);
            }
            db.SubmitChanges();
            return RedirectToAction("HttpNotFound_404","HttpNotFound");
        }

    }
}
