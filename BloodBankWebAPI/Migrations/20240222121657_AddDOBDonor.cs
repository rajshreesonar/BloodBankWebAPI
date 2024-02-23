using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDOBDonor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Donor");

            migrationBuilder.AddColumn<DateTime>(
                name: "Dob",
                table: "Donor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dob",
                table: "Donor");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Donor",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
