using Microsoft.EntityFrameworkCore.Migrations;

namespace TC.DAL.Migrations
{
    public partial class AddingErrorMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "News",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "MembershipTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "MemberMatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "MemberAddresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Lockers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Courts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ErrorMessage",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "News");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "MembershipTypes");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "MemberMatches");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "MemberAddresses");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Courts");

            migrationBuilder.DropColumn(
                name: "ErrorMessage",
                table: "Bills");
        }
    }
}
