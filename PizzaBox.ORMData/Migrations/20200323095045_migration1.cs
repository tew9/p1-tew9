using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.ORMData.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    lastname = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaStore",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    PizzaStoreId = table.Column<long>(nullable: false),
                    Inventory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaStore", x => new { x.Id, x.StoreId });
                    table.ForeignKey(
                        name: "FK_PizzaStore_Pizzas_Id",
                        column: x => x.Id,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaStore_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    totPrice = table.Column<decimal>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaOrder",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    OrderId = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    SizeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => new { x.OrderId, x.Id });
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Pizzas_Id",
                        column: x => x.Id,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaOrder_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5L, "Chicago Deep Dish" },
                    { 7L, "Vegie Pizza" },
                    { 2L, "Chickens Pizza" },
                    { 3L, "Pepperoni" },
                    { 4L, "Cheese Pizza" },
                    { 1L, "The Original Neapolitan" },
                    { 6L, "California Style" }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 3L, "Small", 8.25m },
                    { 2L, "Medium", 10.50m },
                    { 1L, "Large", 13.75m }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Manager", "Name", "location" },
                values: new object[,]
                {
                    { 1L, "fred", "Dominos", "123 bcd st, Arlington tx" },
                    { 2L, "john", "Pizza Hut", "456 DeF, Arlington Tx" },
                    { 3L, "mark", "Papa John's", "456 DeF, Arlington Tx" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "email", "lastname", "password", "type", "username" },
                values: new object[,]
                {
                    { 1L, "tango", "tango@gmail.com", "Tew", "123", "user", "tango" },
                    { 4L, "Andrew", "tango@gmail.com", "AGatep", "123", "user", "drew" },
                    { 2L, "Mark", "mark@gmail.com", "John", "456", "store", "mark" },
                    { 3L, "Dr. Frank", "fred@gmail.com", "Fred", "123", "store", "fred" },
                    { 5L, "William", "john@gmail.com", "John", "123", "store", "john" }
                });

            migrationBuilder.InsertData(
                table: "PizzaStore",
                columns: new[] { "Id", "StoreId", "Inventory", "PizzaStoreId" },
                values: new object[,]
                {
                    { 1L, 1L, 5, 0L },
                    { 2L, 1L, 10, 0L },
                    { 3L, 1L, 20, 0L },
                    { 4L, 1L, 6, 0L },
                    { 1L, 2L, 5, 0L },
                    { 2L, 2L, 10, 0L },
                    { 3L, 2L, 20, 0L },
                    { 4L, 2L, 6, 0L },
                    { 5L, 3L, 6, 0L },
                    { 6L, 3L, 4, 0L },
                    { 1L, 3L, 7, 0L },
                    { 2L, 3L, 6, 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_Id",
                table: "PizzaOrder",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_SizeId",
                table: "PizzaOrder",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaStore_StoreId",
                table: "PizzaStore",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "PizzaStore");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
