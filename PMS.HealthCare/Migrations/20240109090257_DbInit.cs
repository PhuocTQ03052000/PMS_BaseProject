using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PMS.HealthCare.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spotify",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Completed = table.Column<bool>(type: "bit", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spotify", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Spotify",
                columns: new[] { "Id", "Completed", "Title" },
                values: new object[,]
                {
                    { 1, true, "Conan" },
                    { 2, false, "Bảy viên ngọc rồng" },
                    { 3, true, "Shin Cậu Bé Bút Chì" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spotify");
        }
    }
}
