using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DineMaster.Migrations
{
    /// <inheritdoc />
    public partial class hhgy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationSlots_ReservationSlotSlotId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ReservationSlotSlotId",
                table: "Reservations",
                newName: "SlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ReservationSlotSlotId",
                table: "Reservations",
                newName: "IX_Reservations_SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationSlots_SlotId",
                table: "Reservations",
                column: "SlotId",
                principalTable: "ReservationSlots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationSlots_SlotId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "Reservations",
                newName: "ReservationSlotSlotId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_SlotId",
                table: "Reservations",
                newName: "IX_Reservations_ReservationSlotSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationSlots_ReservationSlotSlotId",
                table: "Reservations",
                column: "ReservationSlotSlotId",
                principalTable: "ReservationSlots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
