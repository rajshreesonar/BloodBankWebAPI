using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BloodBankWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDOB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Recipient");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Recipient",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Recipient");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Recipient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
