﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDIenTuAPI.Models;
using System.Net;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
namespace QuanLySanPhamDIenTuAPI.Controllers
{
    [Route("Home/Introduct/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();

        [HttpGet]
        public IEnumerable<KhachHang> Get()
        {
            return db.KhachHang.ToList();
        }

        [HttpGet("{tenDangNhap}/{matKhau}")]
        public async  Task<IActionResult> Get(string tenDangNhap, string matKhau)
        {
            var login =  db.KhachHang.Where(m => m.TenDangNhap == tenDangNhap.Trim() && m.MatKhau == matKhau.Trim()).SingleOrDefault();
            if(login == null)
            {
                return NotFound();
            }    
            return new ObjectResult(login) ;
        }


        // thêm mới một khách hàng
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KhachHang khachHang)
        {
            try
            {
                if(khachHang== null)
                {
                    return BadRequest();
                }    
                else
                {
                    db.KhachHang.Add(khachHang);
                    db.SaveChanges();
                    return new ObjectResult(khachHang); // status 200 => 
                }    
            }
            catch(Exception ex)
            {
                Console.WriteLine("" + ex);
                return BadRequest();
            }
        }

        // cập nhật thông tin cảu một khách hàng
        [HttpPut("{maKhachHang}")]
        public async Task<IActionResult> Put(int maKhachHang, [FromBody] KhachHang khachHang)
        {
            try
            {
                if(khachHang==null || khachHang.MaKhachHang !=maKhachHang)
                {
                    return BadRequest();
                }    
                else
                {
                    var kh = await db.KhachHang.SingleOrDefaultAsync(m => m.MaKhachHang == maKhachHang);
                    if(kh==null)
                    {
                        return NotFound();
                    }    
                    else
                    {
                        kh.TenKhachHang = khachHang.TenKhachHang;
                        kh.SoDienThoai = khachHang.SoDienThoai;
                        kh.Email = khachHang.Email;
                        kh.DiaChi = khachHang.DiaChi;
                        kh.MatKhau = khachHang.MatKhau;
                        await db.SaveChangesAsync();
                        return new ObjectResult(kh); // status 200 => OK

                    }    
                }    
            }
            catch
            {
                return BadRequest(); // status code 400
            }
        }
    }
}
