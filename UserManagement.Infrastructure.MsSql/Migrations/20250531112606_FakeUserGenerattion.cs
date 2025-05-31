using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UserManagement.Infrastructure.MsSql.Migrations
{
    /// <inheritdoc />
    public partial class FakeUserGenerattion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivityTimestamps", "Email", "IsActive", "LastLoginTime", "Name", "PasswordHash", "RegistrationTime" },
                values: new object[,]
                {
                    { 1, "[]", "admin@example.com", true, new DateTime(2025, 5, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2511), "Admin User", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2024, 5, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2498) },
                    { 2, "[]", "john@example.com", true, new DateTime(2025, 5, 30, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2522), "John Smith", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2024, 11, 30, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2518) },
                    { 3, "[]", "sarah@example.com", true, new DateTime(2025, 5, 31, 8, 26, 3, 968, DateTimeKind.Utc).AddTicks(2533), "Sarah Johnson", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2025, 2, 28, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2531) },
                    { 4, "[]", "mike@example.com", false, new DateTime(2025, 5, 21, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2540), "Mike Brown", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2025, 1, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2538) },
                    { 5, "[]", "emily@example.com", true, new DateTime(2025, 5, 31, 6, 26, 3, 968, DateTimeKind.Utc).AddTicks(2546), "Emily Davis", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2025, 3, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2544) },
                    { 6, "[]", "robert@example.com", true, new DateTime(2025, 5, 29, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2559), "Robert Wilson", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2024, 12, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2557) },
                    { 7, "[]", "lisa@example.com", false, new DateTime(2025, 5, 16, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2565), "Lisa Miller", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2024, 10, 31, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2563) },
                    { 8, "[]", "david@example.com", true, new DateTime(2025, 5, 31, 10, 26, 3, 968, DateTimeKind.Utc).AddTicks(2571), "David Taylor", "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8", new DateTime(2025, 4, 30, 11, 26, 3, 968, DateTimeKind.Utc).AddTicks(2569) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
