//api-controller
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet03_webapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.ObjectPool;
using Microsoft.EntityFrameworkCore;

namespace dotnet03_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyNhanVienControllers : ControllerBase
    {
        private readonly QLNVContext _context;
        public QuanLyNhanVienControllers(QLNVContext db)
        {
            _context = db;
        }

        [HttpPost("themNhanVien")]
        public async Task<IActionResult> themNhanVien([FromBody] NhanVienVM nv)
        {
            //linq => sql command
            //sql command raw (viết insert...)

            NhanVien nvInsert = new NhanVien();
            nvInsert.tenNV = nv.tenNV;
            nvInsert.luong = nv.luong;
            nvInsert.maPhongBan = nv.maPhongBan;
            nvInsert.moTa = nv.moTa;
            nvInsert.tuoi = nv.tuoi;
            nvInsert.gioiTinh = nv.gioiTinh;


            await _context.nhanViens.AddAsync(nvInsert);
            _context.SaveChanges(); // áp dụng thay đổi lên database
            return Ok("Thêm nhân viên thành công");
        }

        [HttpPost("themNhanVienraw")]
        public async Task<IActionResult> themNhanVienRaw([FromBody] NhanVienVM nv)
        {
            string sql = @$"INSERT INTO NhanViens(tenNV, luong, maPhongBan, moTa, tuoi, gioiTinh) VALUES ()";
            SqlParameter[] parameters = {
                 
            }

            return Ok("Thêm nhân viên thành công");
        }
    }
}