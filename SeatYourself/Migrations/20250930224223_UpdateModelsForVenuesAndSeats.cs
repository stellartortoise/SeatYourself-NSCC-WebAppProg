using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeatYourself.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelsForVenuesAndSeats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VenueId",
                table: "Occasion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OccasionId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Occasion_OccasionId",
                        column: x => x.OccasionId,
                        principalTable: "Occasion",
                        principalColumn: "OccasionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Seat_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seat",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.NoAction); // <-- Change to NoAction from Cascade, Gemini helped with this to solve fk cascade issue
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venue", x => x.VenueId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_VenueId",
                table: "Seat",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Occasion_VenueId",
                table: "Occasion",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OccasionId",
                table: "Ticket",
                column: "OccasionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SeatId",
                table: "Ticket",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occasion_Venue_VenueId",
                table: "Occasion",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Venue_VenueId",
                table: "Seat",
                column: "VenueId",
                principalTable: "Venue",
                principalColumn: "VenueId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occasion_Venue_VenueId",
                table: "Occasion");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Venue_VenueId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "Venue");

            migrationBuilder.DropIndex(
                name: "IX_Seat_VenueId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Occasion_VenueId",
                table: "Occasion");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "VenueId",
                table: "Occasion");

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Seat",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
