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
using Microsoft.Data.SqlClient;
using System.Data;

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
            string sql = @$"INSERT INTO NhanViens(tenNV, luong, maPhongBan, moTa, tuoi, gioiTinh) VALUES (N'{nv.tenNV}',N'{nv.luong}',N'{nv.maPhongBan}',N'{nv.moTa}',N'{nv.tuoi}',N'{nv.gioiTinh}')";
            await _context.Database.ExecuteSqlRawAsync(sql); //sqlqueryraw: select; execute: insert delete

            return Ok("Thêm nhân viên thành công");
        }

        [HttpGet("getallNhanVienlinq")]
        public async Task<ActionResult> GetAll()
        {
            //linq
            var res = _context.nhanViens.Skip(0).Take(10);
            return Ok(res);
        }

        [HttpGet("getallpaging")]
        public async Task<ActionResult> GetAllPaging([FromQuery] int pageNumber = 10, [FromQuery] int pageSize = 1) //pageNumbe là số phần tử trên 1 trang pageSize là trang số mấy
        {
            int skipElement = (pageSize - 1) * pageNumber;
            //linq
            var res = _context.nhanViens.Skip(skipElement).Take(pageNumber); //
            return Ok(res);
        }

        [HttpGet("getallNhanVienRaw")]
        public async Task<ActionResult> GetAllRaw()
        {
            //raw
            var result = await _context.Database.SqlQueryRaw<NhanVienVM>(
                $@"SELECT tenNV, luong, maPhongBan, moTa, tuoi, gioiTinh FROM NhanViens").ToListAsync();
            return Ok(result);
        }

        [HttpGet("LayThongTinNhanVien/{IdNV}")]
        public async Task<ActionResult> LayThongTinNhanVien([FromRoute] int IdNV)
        {
            //kiểm tra mã nhân viên có tồn tại trong db hay không
            NhanVien? nv = _context.nhanViens.SingleOrDefault(n => n.IdNV == IdNV);
            if (nv != null)
            {
                return Ok(nv);
            }

            return BadRequest("Không tìm thấy nhân viên");
        }

        [HttpGet("layThongTinNhanVienRaw/{IdNV}")]
        public async Task<ActionResult> layThongtinNhanVienRaw([FromRoute] int IdNV)
        {
            // Tạo tham số truy vấn
            SqlParameter paramIdNV = new SqlParameter("@IdNV", SqlDbType.Int) { Value = IdNV };
            var result = await _context.Database.SqlQueryRaw<NhanVienVM>(
                $@"SELECT tenNV,luong,maPhongBan,gioiTinh,moTa,tuoi,gioitinh FROM NhanViens WHERE IdNV = {IdNV};",
                paramIdNV).ToListAsync();
            if (result.Count() == 0)
            {
                return BadRequest("Không tìm thấy nhân viên !");
            }
            return Ok(result[0]);
        }

        [HttpPut("update/{IdNV}")]
        public async Task<ActionResult> updateLinQ([FromRoute] int IdNV, [FromBody] NhanVienVM nvUpdate)
        {
            NhanVien? nvModel = _context.nhanViens.SingleOrDefault(n => n.IdNV == IdNV);
            if (nvModel != null)
            {
                nvModel.tenNV = nvUpdate.tenNV;
                nvModel.gioiTinh = nvUpdate.gioiTinh;
                nvModel.luong = nvUpdate.luong;
                nvModel.moTa = nvUpdate.moTa;
                nvModel.tuoi = nvUpdate.tuoi;
                nvModel.maPhongBan = nvUpdate.maPhongBan;
                _context.SaveChanges();
                return Ok("Cập nhật thành công !");
            }
            return BadRequest("Mã nhân viên không hợp lệ !");
        }

        [HttpDelete("xoaNhanVien/{IdNV}")]
        public async Task<ActionResult> deleteLinQ([FromRoute] int IdNV)
        {
            //Kiểm tra nhân viên có tồn tại hay không 
            NhanVien? nvCheck = await _context.nhanViens.SingleOrDefaultAsync(n => n.IdNV == IdNV);
            if (nvCheck != null)
            {
                //Xoá
                _context.nhanViens.Remove(nvCheck);
                _context.SaveChanges();
                return Ok("Xoá thành công!");
            }
            return BadRequest("Không tìm thấy nhân viên !");
        }
        [HttpDelete("xoaNhanVienRaw/{IdNV}")]
        public async Task<ActionResult> deleteRaw([FromRoute] int IdNV)
        {
            //Kiểm tra nhân viên có tồn tại hay không 
            NhanVien? nvCheck = await _context.nhanViens.SingleOrDefaultAsync(n => n.IdNV == IdNV);
            if (nvCheck == null)
            {
                return BadRequest("Không tìm thấy nhân viên !");
            }
            //Xoá bằng sql raw: ef-sql-delete
            try
            {
                string sql = $@"DELETE FROM NhanViens WHERE IdNV = @paramId;";
                SqlParameter[] parameters = {
                new SqlParameter("@paramId", SqlDbType.Int) { Value = IdNV}
                };
                int affectedRows = await _context.Database.ExecuteSqlRawAsync(sql, parameters);
                return Ok("Xoá nhân viên thành công");
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }

        }
    }
}