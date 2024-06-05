using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curse.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalManagementCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ExternalManagementCompany_ExternalManagementCompanyId",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalManagementCompany",
                table: "ExternalManagementCompany");

            migrationBuilder.RenameTable(
                name: "ExternalManagementCompany",
                newName: "ExternalManagementCompanies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalManagementCompanies",
                table: "ExternalManagementCompanies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses",
                column: "ExternalManagementCompanyId",
                principalTable: "ExternalManagementCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExternalManagementCompanies",
                table: "ExternalManagementCompanies");

            migrationBuilder.RenameTable(
                name: "ExternalManagementCompanies",
                newName: "ExternalManagementCompany");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExternalManagementCompany",
                table: "ExternalManagementCompany",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ExternalManagementCompany_ExternalManagementCompanyId",
                table: "Houses",
                column: "ExternalManagementCompanyId",
                principalTable: "ExternalManagementCompany",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
