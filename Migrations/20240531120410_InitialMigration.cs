using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curse.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestJournals_Employees_EmployeeId",
                table: "RequestJournals");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_RequestJournals_EmployeeId",
                table: "RequestJournals");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RequestTypes",
                newName: "TypeName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RequestStatuses",
                newName: "StatusName");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "RequestJournals",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "ContractExpirationDate",
                table: "ExternalManagementCompanies",
                newName: "ContractEndDate");

            migrationBuilder.AddColumn<int>(
                name: "ExecutorId",
                table: "RequestJournals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ExternalManagementCompanyId",
                table: "Houses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Executors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Executors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestJournals_ExecutorId",
                table: "RequestJournals",
                column: "ExecutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses",
                column: "ExternalManagementCompanyId",
                principalTable: "ExternalManagementCompanies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestJournals_Executors_ExecutorId",
                table: "RequestJournals",
                column: "ExecutorId",
                principalTable: "Executors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestJournals_Executors_ExecutorId",
                table: "RequestJournals");

            migrationBuilder.DropTable(
                name: "Executors");

            migrationBuilder.DropIndex(
                name: "IX_RequestJournals_ExecutorId",
                table: "RequestJournals");

            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "RequestJournals");

            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "RequestTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "RequestStatuses",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "RequestJournals",
                newName: "RegistrationDate");

            migrationBuilder.RenameColumn(
                name: "ContractEndDate",
                table: "ExternalManagementCompanies",
                newName: "ContractExpirationDate");

            migrationBuilder.AlterColumn<int>(
                name: "ExternalManagementCompanyId",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestJournals_EmployeeId",
                table: "RequestJournals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ExternalManagementCompanies_ExternalManagementCompanyId",
                table: "Houses",
                column: "ExternalManagementCompanyId",
                principalTable: "ExternalManagementCompanies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestJournals_Employees_EmployeeId",
                table: "RequestJournals",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
