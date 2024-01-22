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
                    Registration = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CompanyCarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyCars_CompanyCars_CompanyCarId",
                        column: x => x.CompanyCarId,
                        principalTable: "CompanyCars",
                        principalColumn: "Id");
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
                name: "Drives",
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
                    table.PrimaryKey("PK_Drives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drives_CompanyCars_CompanyCarId",
                        column: x => x.CompanyCarId,
                        principalTable: "CompanyCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Drives_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCars_CompanyCarId",
                table: "CompanyCars",
                column: "CompanyCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_CompanyCarId",
                table: "Drives",
                column: "CompanyCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_EmployeeId",
                table: "Drives",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "CompanyCars");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
