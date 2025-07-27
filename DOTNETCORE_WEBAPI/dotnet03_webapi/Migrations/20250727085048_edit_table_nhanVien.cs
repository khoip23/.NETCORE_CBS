using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet03_webapi.Migrations
{
    /// <inheritdoc />
    public partial class edit_table_nhanVien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tuoi",
                table: "nhanViens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tuoi",
                table: "nhanViens");
        }
    }
}
