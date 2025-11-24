using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingCars.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedDateProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CarDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ae7a7a1-1d2f-4457-b681-f3e87d4ebcfe", "AQAAAAIAAYagAAAAELvcL9JVLXyx9PjROY1EZZ6V5ZaqOJ/ewcLarEktsXK5BUA/PBYToJDe/rQjGkz6rg==", "54a8d41d-cb1d-447d-ab15-089278083520" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "07e05620-ef89-48be-859f-b8d829ed6d8a", "AQAAAAIAAYagAAAAEOAJDOKPquFNxZGNUEtKpE3hTS10NB61AyYHCtcuLENyGofGl5pUGhuNa7ZglxM1/g==", "aed879c2-4495-44c0-a236-28c90763c4b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8a9d442b-6937-4d51-bf87-cda93805d265", "AQAAAAIAAYagAAAAEPmL1YiV+5HLcikxXtnvP0MflL2nMcIRhxWEQUjH9Y2QLJeg7O61KC6RP+DkNpbLoA==", "d75dac83-9fc3-4625-b498-f5a775c2a2b2" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "CarDate",
                value: new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "CarDate",
                value: new DateTime(2021, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3,
                column: "CarDate",
                value: new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarDate",
                table: "Cars");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bc21fb54-5bfd-46ca-8ad7-4d365a1f85c1", "AQAAAAIAAYagAAAAEC8GWWAA5Pwwg7nUjGU3xyM62K3LjuzmWsfKcETYUmL5VqBCCoA/7PUGZzXjHF6pcw==", "348a508e-5dd0-4a84-8d65-a274bd3a1bf2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ce38047-1014-4c5d-913d-35334ba2501e", "AQAAAAIAAYagAAAAEBQaFqWD11wSljmBh7KYgNe+ZIRlh3/5m50rxAomBaS5DCvyGcojn0but2vMTFBmkA==", "30e49d41-61dc-4ad1-be0b-b9d4375f6e4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "385911f7-c92d-457a-ae3e-403ee273b228", "AQAAAAIAAYagAAAAEHb18rrmgslcDFn158tDYyOyoLC5P4LRiQmQGXPWm2PrnY1fEN784Km63xfwKtvxYg==", "571cd59e-afc9-4e97-8f78-f46b75864083" });
        }
    }
}
