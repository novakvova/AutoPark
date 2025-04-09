using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAutoPark.Migrations
{
    /// <inheritdoc />
    public partial class AddtblAssignments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblAssignments_tblDrivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "tblDrivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAssignments_tblRoutes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "tblRoutes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblAssignments_tblVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "tblVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignments_DriverId",
                table: "tblAssignments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignments_RouteId",
                table: "tblAssignments",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_tblAssignments_VehicleId",
                table: "tblAssignments",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAssignments");
        }
    }
}
