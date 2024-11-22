using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovePostContentSubEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content_Description",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Content_Title",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Content_Images",
                table: "Posts",
                newName: "Images");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "Images",
                table: "Posts",
                newName: "Content_Images");

            migrationBuilder.AddColumn<string>(
                name: "Content_Description",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content_Title",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
