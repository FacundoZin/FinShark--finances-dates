using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class addonetoonebetweenusercomment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_AspNetUsers_appuserID",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Stocks_stockid",
                table: "Portfolios");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "06a20595-8787-4878-8001-09e16d0c53ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57887424-a029-40c0-814d-bd1a4b295c7f");

            migrationBuilder.RenameColumn(
                name: "stockid",
                table: "Portfolios",
                newName: "StockID");

            migrationBuilder.RenameColumn(
                name: "appuserID",
                table: "Portfolios",
                newName: "AppUserID");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolios_stockid",
                table: "Portfolios",
                newName: "IX_Portfolios_StockID");

            migrationBuilder.AddColumn<string>(
                name: "AppUserID",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8d7b0d4a-aa91-4a58-adff-45c0af148eb8", null, "Admin", "ADMIN" },
                    { "bf525fd5-f1b9-4aa9-94fc-93a007c79414", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments",
                column: "AppUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_AspNetUsers_AppUserID",
                table: "Portfolios",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Stocks_StockID",
                table: "Portfolios",
                column: "StockID",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AppUserID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_AspNetUsers_AppUserID",
                table: "Portfolios");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolios_Stocks_StockID",
                table: "Portfolios");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AppUserID",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d7b0d4a-aa91-4a58-adff-45c0af148eb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf525fd5-f1b9-4aa9-94fc-93a007c79414");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "StockID",
                table: "Portfolios",
                newName: "stockid");

            migrationBuilder.RenameColumn(
                name: "AppUserID",
                table: "Portfolios",
                newName: "appuserID");

            migrationBuilder.RenameIndex(
                name: "IX_Portfolios_StockID",
                table: "Portfolios",
                newName: "IX_Portfolios_stockid");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06a20595-8787-4878-8001-09e16d0c53ca", null, "User", "USER" },
                    { "57887424-a029-40c0-814d-bd1a4b295c7f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_AspNetUsers_appuserID",
                table: "Portfolios",
                column: "appuserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolios_Stocks_stockid",
                table: "Portfolios",
                column: "stockid",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
