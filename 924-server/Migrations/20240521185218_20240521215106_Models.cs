using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _924_server.Migrations
{
    /// <inheritdoc />
    public partial class _20240521215106_Models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberParticipants",
                table: "Chats");

            migrationBuilder.AddColumn<string>(
                name: "ProfilePhotoUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfilePhotoUrl",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "NumberParticipants",
                table: "Chats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
