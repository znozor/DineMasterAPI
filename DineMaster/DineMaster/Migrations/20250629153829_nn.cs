using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DineMaster.Migrations
{
    /// <inheritdoc />
    public partial class nn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationSlots_SlotId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_SlotId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "SlotId",
                table: "Reservations",
                newName: "GuestCount");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Reservations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "EndTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "ReservationSlotSlotId",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "StartTime",
                table: "Reservations",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationSlotSlotId",
                table: "Reservations",
                column: "ReservationSlotSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationSlots_ReservationSlotSlotId",
                table: "Reservations",
                column: "ReservationSlotSlotId",
                principalTable: "ReservationSlots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_ReservationSlots_ReservationSlotSlotId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservationSlotSlotId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservationSlotSlotId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "GuestCount",
                table: "Reservations",
                newName: "SlotId");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_SlotId",
                table: "Reservations",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_ReservationSlots_SlotId",
                table: "Reservations",
                column: "SlotId",
                principalTable: "ReservationSlots",
                principalColumn: "SlotId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
