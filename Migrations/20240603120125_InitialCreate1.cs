using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curse.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "RequestJournals");

            migrationBuilder.InsertData(
                table: "RequestStatuses",
                columns: new[] { "Id", "StatusName" },
                values: new object[,]
                {
                    { 1, "Зарегистрировано" },
                    { 2, "На рассмотрении" },
                    { 3, "Отправка специалиста" },
                    { 4, "Решено" },
                    { 5, "Не решено" }
                });

            migrationBuilder.InsertData(
                table: "RequestTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Устранение утечек воды, газа" },
                    { 2, "Заявки на уборку и санитарное обслуживание" },
                    { 3, "Проверка работы систем отопления, вентиляции, кондиционирования" },
                    { 4, "Проверка пожарной сигнализации и систем безопасности" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RequestStatuses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RequestTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RequestTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RequestTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RequestTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "RequestJournals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
