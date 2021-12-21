using Microsoft.EntityFrameworkCore.Migrations;

namespace TRS.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptedTime_Project_ProjectCode",
                table: "AcceptedTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Subactivity_Project_ProjectCode",
                table: "Subactivity");

            migrationBuilder.DropIndex(
                name: "IX_Subactivity_ProjectCode",
                table: "Subactivity");

            migrationBuilder.DropIndex(
                name: "IX_AcceptedTime_ProjectCode",
                table: "AcceptedTime");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Subactivity");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "AcceptedTime");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Subactivity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "AcceptedTime",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subactivity_Code",
                table: "Subactivity",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedTime_Code",
                table: "AcceptedTime",
                column: "Code");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedTime_Project_Code",
                table: "AcceptedTime",
                column: "Code",
                principalTable: "Project",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subactivity_Project_Code",
                table: "Subactivity",
                column: "Code",
                principalTable: "Project",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcceptedTime_Project_Code",
                table: "AcceptedTime");

            migrationBuilder.DropForeignKey(
                name: "FK_Subactivity_Project_Code",
                table: "Subactivity");

            migrationBuilder.DropIndex(
                name: "IX_Subactivity_Code",
                table: "Subactivity");

            migrationBuilder.DropIndex(
                name: "IX_AcceptedTime_Code",
                table: "AcceptedTime");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Subactivity");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "AcceptedTime");

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "Subactivity",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "AcceptedTime",
                type: "varchar(767)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subactivity_ProjectCode",
                table: "Subactivity",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_AcceptedTime_ProjectCode",
                table: "AcceptedTime",
                column: "ProjectCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AcceptedTime_Project_ProjectCode",
                table: "AcceptedTime",
                column: "ProjectCode",
                principalTable: "Project",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subactivity_Project_ProjectCode",
                table: "Subactivity",
                column: "ProjectCode",
                principalTable: "Project",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
