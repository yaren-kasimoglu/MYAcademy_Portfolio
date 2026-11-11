using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MYAcademy_Portfolio.Migrations
{
    /// <inheritdoc />
    public partial class AddSkillLevelPercentage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LevelPercentage",
                table: "Skills",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LevelPercentage",
                table: "Skills");
        }
    }
}
