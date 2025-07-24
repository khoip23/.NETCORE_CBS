//api-controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

//using dotnet03_webapi.Models;

namespace dotnet03_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        public static List<SanPham> lstSanPham = new List<SanPham>()
        {
            new SanPham()
            {
                maSP = 1,
                tenSP = "iphone",
                gia = 10000,
            },
            new SanPham()
            {
                maSP = 2,
                tenSP = "iphone11",
                gia = 20000,
            },
            new SanPham()
            {
                maSP = 3,
                tenSP = "iphone13",
                gia = 30000,
            },
            new SanPham()
            {
                maSP = 4,
                tenSP = "iphone16",
                gia = 40000,
            },
        };

        public SanPhamController() { }

        [HttpGet("layDanhSachSanPham")] //định nghĩa api lấy dữ liệu (viết theo chuẩn resful api)
        public async Task<IActionResult> GetSanPham()
        {
            return Ok(new HttpResponseModel<List<SanPham>>()
            {
                data = lstSanPham
            });

            
        }

        [HttpGet("GetInfoProd/{maSP}")]
        public async Task<IActionResult> GetSanPham([FromRoute] int maSP)
        {
            SanPham? sp = lstSanPham.Find(sp => sp.maSP == maSP);
            if (sp != null)
            {
                return Ok(new HttpResponseModel<SanPham>
                {
                    data = sp
                });
            }
            return BadRequest("Không tìm thấy sản phẩm");
        }

        [HttpPost("AddProd")]
        public async Task<string> PostSanPham([FromBody] SanPham sp)
        {
            lstSanPham.Add(sp);
            return "Thêm thành công";
        }

        [HttpPut("CapNhatSP/{maSP}")]
        public async Task<string> CapNhatSP([FromRoute] int maSP, [FromBody] SanPham sanPhamCapNhat)
        {
            SanPham sUpdate = lstSanPham.Find(sp => sp.maSP == maSP);
            if (sUpdate != null)
            {
                sUpdate.tenSP = sanPhamCapNhat.tenSP;
                sUpdate.gia = sanPhamCapNhat.gia;
                return "Cập nhật thành công";
            }

            return "Không tìm thấy sản phẩm";
        }

        [HttpDelete("XoaSanPham/{maSP}")]
        public async Task<string> DeleteSanPham([FromRoute] int maSP)
        {
            SanPham sRemove = lstSanPham.Find(sp => sp.maSP == maSP);
            if (sRemove != null)
            {
                lstSanPham.Remove(sRemove);
                return "xóa thành công";
            }

            return "Không tìm thấy sản phẩm";
        }

        [HttpGet("timSP")]
        public async Task<List<SanPham>> timKiemSanPham([FromQuery] string tuKhoa)
        {
            var lstRes = lstSanPham.Where(sp => sp.tenSP.Contains(tuKhoa));
            if (lstRes.Count() > 0)
            {
                return lstRes.ToList();
            }

            return null;
        }
    }
}
