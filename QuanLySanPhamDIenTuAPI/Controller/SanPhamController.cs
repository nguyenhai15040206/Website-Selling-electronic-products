using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLySanPhamDIenTuAPI.Models;

namespace QuanLySanPhamDIenTuAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();


        public List<SanPham> getSanPhamPaginationList(int page = 1, int limit = 10)
        {
            //var listModel = new SanPhamPaginationList();
            var listModel = new List<SanPham>();
            var sp = db.SanPham.Skip((page - 1) * limit).Take(limit).ToList();
            listModel = sp;
            int totalRecord = db.Banner.Count();
            var pagination = new Pagination
            {
                count = totalRecord,
                currentPage = page,
                pagsize = limit,
                totalPage = (int)Math.Ceiling(decimal.Divide(totalRecord, limit)),
                indexOne = ((page - 1) * limit + 1),
                indexTwo = (((page - 1) * limit + limit) <= totalRecord ? ((page - 1) * limit * limit) : totalRecord)
            };
            //listModel.pagination = pagination;
            return listModel;
        }

        [HttpGet("getSanPhamPaginationList")]
        public ActionResult<SanPham> GET(int page, int limit)
        {
            var rs = getSanPhamPaginationList(page, limit);
            if (rs == null)
            {
                return NotFound(rs);
            }
            return Ok(rs);
        }
        // load sản phẩm theo mã sản phẩm
        [HttpGet("{maSanPham}")]
        public async Task<IActionResult> Get(int maSanPham)
        {
            var SanPham = db.SanPham.Where(m => m.MaSanPham == maSanPham).FirstOrDefault();
            if (SanPham == null)
            {
                return NotFound();
            }
            return new ObjectResult(SanPham);
        }

        // load sản phẩm theo ghichu
        [HttpGet("ghiChu/{ghiChu}")]
        public async Task<IActionResult> Get(string ghiChu)
        { 
            var sp = db.SanPham.Where(m => m.MaDanhMucNavigation.GhiChu == ghiChu).ToList();
            if(sp.Count ==0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }
        [HttpGet("Apple")]
        public async Task<IActionResult> Get(string Iphone="Iphone", string Macbook = "Macbook")
        {
            var sp = (from a in db.DanhMuc
                      join b in db.SanPham on a.MaDanhMuc equals b.MaDanhMuc
                      where a.TenDanhMuc == Iphone || a.TenDanhMuc == Macbook
                      select b).ToList();
            if (sp.Count == 0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }

        // load sản phẩm theo danh mục
        [HttpGet("DanhMuc/{maDanhMuc}")]
        public async Task<IActionResult> Get(int? maDanhMuc)
        {
            var sp = db.SanPham.Where(m => m.MaDanhMucNavigation.MaDanhMuc == maDanhMuc).ToList();
            if(sp.Count==0)
            {
                return NotFound();
            }
            return new ObjectResult(sp);
        }
    }
}
