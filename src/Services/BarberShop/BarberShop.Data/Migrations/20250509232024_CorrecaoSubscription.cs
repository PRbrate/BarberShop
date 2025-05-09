using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscription_UserId",
                schema: "dbo",
                table: "Subscription");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId",
                schema: "dbo",
                table: "Subscription",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscription_UserId",
                schema: "dbo",
                table: "Subscription");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_UserId",
                schema: "dbo",
                table: "Subscription",
                column: "UserId");
        }
    }
}
