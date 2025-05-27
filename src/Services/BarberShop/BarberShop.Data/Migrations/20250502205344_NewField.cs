using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinish",
                schema: "dbo",
                table: "Service",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinish",
                schema: "dbo",
                table: "Service");
        }
    }
}
