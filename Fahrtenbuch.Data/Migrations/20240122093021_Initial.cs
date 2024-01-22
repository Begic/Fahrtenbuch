using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fahrtenbuch.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyCars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Passwort = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCarEmployee",
                columns: table => new
                {
                    CompanyCarsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCarEmployee", x => new { x.CompanyCarsId, x.EmployeesId });
                    table.ForeignKey(
                        name: "FK_CompanyCarEmployee_CompanyCars_CompanyCarsId",
                        column: x => x.CompanyCarsId,
                        principalTable: "CompanyCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyCarEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTimeStamp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TravelRoute = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    PurposeOfTrip = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DepartureMileage = table.Column<int>(type: "int", nullable: true),
                    ArrivalMileage = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CompanyCarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_CompanyCars_CompanyCarId",
                        column: x => x.CompanyCarId,
                        principalTable: "CompanyCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCarEmployee_EmployeesId",
                table: "CompanyCarEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CompanyCarId",
                table: "Trips",
                column: "CompanyCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_EmployeeId",
                table: "Trips",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyCarEmployee");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "CompanyCars");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
