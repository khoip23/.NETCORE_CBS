using Microsoft.EntityFrameworkCore;

namespace dotnet03_webapi.Models
{
    public class QLNVContext : DbContext
    {
        public QLNVContext() { }
        public QLNVContext(DbContextOptions<QLNVContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connectionstring
            optionsBuilder.UseSqlServer("Server=127.0.0.1,1433; Database=QuanLyNhanVienDB;User Id = sa;Passwork=Khoideptrai312@;Integrated Security=True;TrustServerCertìicate=True");
        }

        public DbSet<PhongBan> PhongBans { get; set; }
        public DbSet<NhanVien> nhanViens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //thiết lập các khóa ngoại ràng buộc toàn vẹn.....
            modelBuilder.Entity<PhongBan>().HasMany(p => p.nhanViens).WithOne(nv => nv.phongban).HasForeignKey(nv => nv.maPhongBan);
        }
    }
}