using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatYourself.Migrations
{
    /// <inheritdoc />
    public partial class GotRidOfVenueOG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Venue",
                table: "Occasion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Venue",
                table: "Occasion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
