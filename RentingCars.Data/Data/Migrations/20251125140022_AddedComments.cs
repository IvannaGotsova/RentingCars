using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentingCars.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CarDate",
                table: "Cars",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c919cf86-e8f9-4301-817a-0c0c6683f2ca", "AQAAAAIAAYagAAAAEO7u/lRTKKXDj80rYTE9sk222pJjD7zsptsga4Fjdt34VrHdL+OAKGPk83QN9iH1tw==", "2862daa6-44cc-4dce-ac9d-4ce981f25cab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcb4f072-ecca-43c9-ab26-c060c6f364e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea6b9f77-f97b-4d78-9f36-9194024167ee", "AQAAAAIAAYagAAAAEBvTKqKPYwBPhZi5C9IrUD7C5qbr/XBEw9/esXysD4lra8s7rvzpgo366N6JifPntQ==", "a47bac3e-ef6f-4140-9c87-4579efed6940" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b6b29f8-52cc-4e3b-9957-3c9b89e35b90", "AQAAAAIAAYagAAAAEFc45zPAW//wlFems9JaJidSyReBEC/UGLBQlpyrD8dJSG8z/lQ6wupg0zOCKlgLlg==", "4060b26c-d8b7-406b-993e-e4f4a57ee42d" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CarId",
                table: "Comments",
                column: "CarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CarDate",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

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
        }
    }
}
