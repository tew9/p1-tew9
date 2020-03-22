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
                name: "PizzaSize",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    SizeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaSize", x => new { x.SizeId, x.Id });
                    table.ForeignKey(
                        name: "FK_PizzaSize_Pizzas_Id",
                        column: x => x.Id,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaSize_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    orderId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderTime = table.Column<DateTime>(nullable: false),
                    totPrice = table.Column<decimal>(nullable: false),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Users_UserId",
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
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaOrder", x => new { x.Id, x.OrderId });
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
                        principalColumn: "orderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PizzaStore",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    StoreId = table.Column<long>(nullable: false),
                    Inventory = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaStore", x => new { x.StoreId, x.Id });
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
                    { 1L, "Large", 13.75m },
                    { 2L, "Medium", 10.50m },
                    { 3L, "Small", 8.25m }
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
                table: "PizzaSize",
                columns: new[] { "SizeId", "Id" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 1L, 2L },
                    { 1L, 3L },
                    { 1L, 4L },
                    { 2L, 1L },
                    { 2L, 2L },
                    { 2L, 3L },
                    { 2L, 4L },
                    { 3L, 1L },
                    { 3L, 2L },
                    { 3L, 3L },
                    { 3L, 4L }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Name", "UserId", "location" },
                values: new object[,]
                {
                    { 1L, "Dominos", 2L, "123 bcd st, Arlington tx" },
                    { 2L, "Pizza Hut", 3L, "456 DeF, Arlington Tx" },
                    { 3L, "Papa John's", 3L, "456 DeF, Arlington Tx" }
                });

            migrationBuilder.InsertData(
                table: "PizzaStore",
                columns: new[] { "StoreId", "Id", "Inventory" },
                values: new object[,]
                {
                    { 1L, 1L, 5 },
                    { 1L, 2L, 10 },
                    { 1L, 3L, 20 },
                    { 1L, 4L, 6 },
                    { 2L, 1L, 5 },
                    { 2L, 2L, 10 },
                    { 2L, 3L, 20 },
                    { 2L, 4L, 6 },
                    { 3L, 5L, 6 },
                    { 3L, 6L, 4 },
                    { 3L, 1L, 7 },
                    { 3L, 2L, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaOrder_OrderId",
                table: "PizzaOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaSize_Id",
                table: "PizzaSize",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaStore_Id",
                table: "PizzaStore",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaOrder");

            migrationBuilder.DropTable(
                name: "PizzaSize");

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
