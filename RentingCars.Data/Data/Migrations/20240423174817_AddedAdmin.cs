using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingCars.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b32067d-2520-45ce-8b15-80e6ceadb493", "AQAAAAIAAYagAAAAEKsvTkSZS90GL48Gwud5jfWl7Ul4q3+oqW4sIuXjr1J2SdsyIQ8bg0UTyOEMShoXyQ==", "b1213734-f38b-4d08-9432-5a550a6f805a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f17b13ca-0dec-4901-ac4c-a4cfa373427a", "AQAAAAIAAYagAAAAEAqXX+mDKZeLhEwEH4QlbIaiONKNoVskhkSDZeSAflhGB5Sy0jJOtRm0tnDz7ef8IA==", "d3699943-3990-4ce8-8510-33c2d775b0e0" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcb4f072-ecca-43c9-ab26-c060c6f364e4", 0, "3683e527-d75a-41d4-9b8f-574e5272e992", "admin@mail.com", false, "Admin", "Admin", false, null, "admin@mail.com", "admin@mail.com", "AQAAAAIAAYagAAAAEDzJLZqAetVm7Bfa1Y2aRl5HTSsINmcUdG2sVmjeNsLYv83OFYT943aJ+gwdL8EuhQ==", null, false, "a81eaebd-d4a1-4bb2-9476-9429df819cb3", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Brokers",
                columns: new[] { "Id", "BrokerPhoneNumber", "UserId" },
                values: new object[] { 2, "+0000000000", "bcb4f072-ecca-43c9-ab26-c060c6f364e4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brokers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e71cfad6-ce5e-4d8b-a828-6664056c51b4", "AQAAAAIAAYagAAAAEBU4nJfx3Srn4whGJJkstMNlk4EwqYBlMSa3pF+5b/hiFAwz2t2mJmtyIbA889TqYw==", "09323caf-8927-4657-bcde-65c9efc4d417" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e80f35e-6f63-465f-b021-66ccb59a4cd2", "AQAAAAIAAYagAAAAECovzkxLmtbiDi+iL3h7PKR9mC1GAYfRaRHyHdrbN17279mgUZwvCotlS2R3i76kxg==", "377b07df-4e43-4dcb-97b2-1921bdd47945" });
        }
    }
}
