using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace REST_API_.Net_Core.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", maxLength: 50, nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CateogryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Category_CateogryID",
                        column: x => x.CateogryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[] { new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "First Category" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CateogryID", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "D:/Monthly Tasks/Building REST API using .Net Core/REST API .Net Core/Images/Bitmap.png", "First Product", 1m, 1m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CateogryID", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[] { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"), "D:/Monthly Tasks/Building REST API using .Net Core/REST API .Net Core/Images/shutterstock_662279290.png", "Second Product", 1m, 1m });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CateogryID",
                table: "Products",
                column: "CateogryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
