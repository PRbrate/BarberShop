using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haircut_AspNetUsers_UserId",
                schema: "dbo",
                table: "Haircut");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                schema: "dbo",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                schema: "dbo",
                table: "Subscription");

            migrationBuilder.AddForeignKey(
                name: "FK_Haircut_AspNetUsers_UserId",
                schema: "dbo",
                table: "Haircut",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                schema: "dbo",
                table: "Service",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                schema: "dbo",
                table: "Subscription",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Haircut_AspNetUsers_UserId",
                schema: "dbo",
                table: "Haircut");

            migrationBuilder.DropForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                schema: "dbo",
                table: "Service");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                schema: "dbo",
                table: "Subscription");

            migrationBuilder.AddForeignKey(
                name: "FK_Haircut_AspNetUsers_UserId",
                schema: "dbo",
                table: "Haircut",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_AspNetUsers_UserId",
                schema: "dbo",
                table: "Service",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_AspNetUsers_UserId",
                schema: "dbo",
                table: "Subscription",
                column: "UserId",
                principalSchema: "dbo",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
