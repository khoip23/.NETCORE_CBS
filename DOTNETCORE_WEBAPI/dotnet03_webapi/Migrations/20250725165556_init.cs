using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet03_webapi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    maPhongBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    diaDiem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.maPhongBan);
                });

            migrationBuilder.CreateTable(
                name: "nhanViens",
                columns: table => new
                {
                    IdNV = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenNV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    luong = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    gioiTinh = table.Column<bool>(type: "bit", nullable: false),
                    maPhongBan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhanViens", x => x.IdNV);
                    table.ForeignKey(
                        name: "FK_nhanViens_PhongBans_maPhongBan",
                        column: x => x.maPhongBan,
                        principalTable: "PhongBans",
                        principalColumn: "maPhongBan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nhanViens_maPhongBan",
                table: "nhanViens",
                column: "maPhongBan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nhanViens");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
