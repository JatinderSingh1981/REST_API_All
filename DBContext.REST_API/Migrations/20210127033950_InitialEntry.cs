using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DBContext.REST_API.Migrations
{
    public partial class InitialEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessorType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessorType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ComputerTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    BrandId = table.Column<int>(type: "INTEGER", nullable: false),
                    USBPorts = table.Column<int>(type: "INTEGER", nullable: false),
                    RamSlots = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FormFactorId = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desktops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ScreenSize = table.Column<int>(type: "INTEGER", nullable: false),
                    Timestamp = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Laptops_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "HP" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Dell" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Lenovo" });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Microsoft" });

            migrationBuilder.InsertData(
                table: "FormFactor",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "MidTower" });

            migrationBuilder.InsertData(
                table: "FormFactor",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Tower" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "i3" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "i5" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "i7" });

            migrationBuilder.InsertData(
                table: "ProcessorType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "i9" });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Desktop" });

            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Laptop" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "ComputerTypeId", "Description", "ProcessorId", "Quantity", "RamSlots", "USBPorts" },
                values: new object[] { 1, 2, 1, "Added the Desktop product through Seeding", 1, 100, 4, 3 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BrandId", "ComputerTypeId", "Description", "ProcessorId", "Quantity", "RamSlots", "USBPorts" },
                values: new object[] { 2, 1, 2, "Added the Laptop product through Seeding", 2, 50, 2, 3 });

            migrationBuilder.InsertData(
                table: "Desktops",
                columns: new[] { "Id", "FormFactorId", "ProductId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "ProductId", "ScreenSize" },
                values: new object[] { 2, 2, 15 });

            migrationBuilder.CreateIndex(
                name: "IX_Desktops_ProductId",
                table: "Desktops",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_ProductId",
                table: "Laptops",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Desktops");

            migrationBuilder.DropTable(
                name: "FormFactor");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "ProcessorType");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
