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
                maSP = 1,
                tenSP = "iphone11",
                gia = 20000,
            },
            new SanPham()
            {
                maSP = 1,
                tenSP = "iphone13",
                gia = 30000,
            },
        };

        public SanPhamController() { }

        [HttpGet("layDanhSachSanPham")] //định nghĩa api lấy dữ liệu (viết theo chuẩn resful api)
        public async Task<List<SanPham>> GetSanPham()
        {
            return lstSanPham;
        }
    }
}
