using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRS.Migrations
{
    public partial class timestamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Subactivity",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Report",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "ActivityEntry",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "AcceptedTime",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Subactivity");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "ActivityEntry");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "AcceptedTime");
        }
    }
}
