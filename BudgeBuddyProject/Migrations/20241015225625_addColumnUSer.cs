using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BudgeBuddyProject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AllowdSendEmail",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ExpireMonth",
                table: "FixedBill",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AllowdSendEmail",
                table: "User");

            migrationBuilder.AlterColumn<int>(
                name: "ExpireMonth",
                table: "FixedBill",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
