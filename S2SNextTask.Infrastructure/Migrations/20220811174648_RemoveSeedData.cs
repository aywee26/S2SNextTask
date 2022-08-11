using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace S2SNextTask.Infrastructure.Migrations
{
    public partial class RemoveSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("51f8077d-2a37-455d-8cdb-3d531f2f277b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b84b9b1c-688a-4b0d-ac8f-a0a2d93ccb2c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublicationDate", "Title" },
                values: new object[] { new Guid("51f8077d-2a37-455d-8cdb-3d531f2f277b"), "Ремарк Эрих", new DateTime(1945, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Триумфальная арка" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublicationDate", "Title" },
                values: new object[] { new Guid("b84b9b1c-688a-4b0d-ac8f-a0a2d93ccb2c"), "Ремарк Эрих", new DateTime(1936, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Три товарища" });
        }
    }
}
