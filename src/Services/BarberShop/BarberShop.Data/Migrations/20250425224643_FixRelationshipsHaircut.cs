using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixRelationshipsHaircut : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Haircut_id",
                schema: "dbo",
                table: "Service",
                newName: "HaircutId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_HaircutId",
                schema: "dbo",
                table: "Service",
                column: "HaircutId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Haircut_HaircutId",
                schema: "dbo",
                table: "Service",
                column: "HaircutId",
                principalSchema: "dbo",
                principalTable: "Haircut",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Haircut_HaircutId",
                schema: "dbo",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "IX_Service_HaircutId",
                schema: "dbo",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "HaircutId",
                schema: "dbo",
                table: "Service",
                newName: "Haircut_id");
        }
    }
}
