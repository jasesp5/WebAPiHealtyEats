using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPiHealtyEats.Migrations
{
    /// <inheritdoc />
    public partial class healtStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthStatusId",
                table: "Restaurant",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HealthStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HealthStatuses",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "Healthy" },
                    { 2, "Moderate" },
                    { 3, "Unhealthy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthStatuses");

            migrationBuilder.DropColumn(
                name: "HealthStatusId",
                table: "Restaurant");
        }
    }
}
