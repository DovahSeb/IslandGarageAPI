using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandGarageAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_VehicleImageId_to_Vehicles_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleImageId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleImageId",
                table: "Vehicles");
        }
    }
}
