using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IslandGarageAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_VehicleImage_FK_to_Vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "VehicleImageId",
                table: "Vehicles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleImageId",
                table: "Vehicles",
                column: "VehicleImageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleImages_VehicleImageId",
                table: "Vehicles",
                column: "VehicleImageId",
                principalTable: "VehicleImages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleImages_VehicleImageId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleImageId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleImageId",
                table: "Vehicles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
