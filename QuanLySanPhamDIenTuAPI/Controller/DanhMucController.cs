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
    public class DanhMucController : ControllerBase
    {
        QL_SanPhamContext db = new QL_SanPhamContext();
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var danhMuc = db.DanhMuc.ToList();
            if(danhMuc.Count==0)
            {
                return NotFound();
            }
            return new ObjectResult(danhMuc);
        }

        [HttpGet("{ghiChu}")]
        public async Task<IActionResult> Get(string ghiChu)
        {
            var danhMUc = db.DanhMuc.Where(m => m.GhiChu == ghiChu).ToList();
            if(danhMUc.Count==0)
            {
                return NotFound();
            }
            return new ObjectResult(danhMUc);
        }
    }
}
