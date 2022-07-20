using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Labb1_Entity_Framework.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplications",
                columns: table => new
                {
                    LeaveId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    CurrentDate = table.Column<DateTime>(nullable: false),
                    ForeignEmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.LeaveId);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_Employees_ForeignEmployeeId",
                        column: x => x.ForeignEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Jonathan", "Johansson" },
                    { 2, "Emmy", "Johansson" },
                    { 3, "Daniel", "West" },
                    { 4, "Lisa", "Gerzen" },
                    { 5, "Bob", "Johansson" }
                });

            migrationBuilder.InsertData(
                table: "LeaveApplications",
                columns: new[] { "LeaveId", "CurrentDate", "EndDate", "ForeignEmployeeId", "Reason", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sick", new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vacation", new DateTime(2022, 4, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Ski vacation", new DateTime(2022, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Home sick with kids", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Vacation", new DateTime(2022, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Sick children", new DateTime(2022, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_ForeignEmployeeId",
                table: "LeaveApplications",
                column: "ForeignEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApplications");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
