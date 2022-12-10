using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSM.Migrations
{
    /// <inheritdoc />
    public partial class updatebookingTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "DriverId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RouteId",
                table: "Bookings",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Routes_RouteId",
                table: "Bookings",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Routes_RouteId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RouteId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Bookings");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
