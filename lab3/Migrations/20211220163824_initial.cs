using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace TRS.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Code = table.Column<string>(nullable: false),
                    Manager = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(nullable: true),
                    Month = table.Column<DateTime>(nullable: false),
                    Frozen = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ReportID);
                });

            migrationBuilder.CreateTable(
                name: "Subactivity",
                columns: table => new
                {
                    SubactivityID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subactivity", x => x.SubactivityID);
                    table.ForeignKey(
                        name: "FK_Subactivity_Project_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Project",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcceptedTime",
                columns: table => new
                {
                    AcceptedTimeID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Time = table.Column<int>(nullable: false),
                    ReportID = table.Column<int>(nullable: true),
                    ProjectCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcceptedTime", x => x.AcceptedTimeID);
                    table.ForeignKey(
                        name: "FK_AcceptedTime_Project_ProjectCode",
                        column: x => x.ProjectCode,
                        principalTable: "Project",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcceptedTime_Report_ReportID",
                        column: x => x.ReportID,
                        principalTable: "Report",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActivityEntry",
                columns: table => new
                {
                    ActivityEntryID = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReportID = table.Column<int>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Subcode = table.Column<string>(nullable: true),
                    Time = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityEntry", x => x.ActivityEntryID);
                    table.ForeignKey(
                        name: "FK_ActivityEntry_Project_Code",
                        column: x => x.Code,
                        principalTable: "Project",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityEntry_Report_ReportID",
                        column: x => x.ReportID,
                        principalTable: "Report",
                        principalColumn: "ReportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedTime_ProjectCode",
                table: "AcceptedTime",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedTime_ReportID",
                table: "AcceptedTime",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_Code",
                table: "ActivityEntry",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityEntry_ReportID",
                table: "ActivityEntry",
                column: "ReportID");

            migrationBuilder.CreateIndex(
                name: "IX_Subactivity_ProjectCode",
                table: "Subactivity",
                column: "ProjectCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcceptedTime");

            migrationBuilder.DropTable(
                name: "ActivityEntry");

            migrationBuilder.DropTable(
                name: "Subactivity");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
