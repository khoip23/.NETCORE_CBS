using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnet03_webapi.Migrations
{
    /// <inheritdoc />
    public partial class innit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "moTa",
                table: "nhanViens",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "moTa",
                table: "nhanViens");
        }
    }
}
