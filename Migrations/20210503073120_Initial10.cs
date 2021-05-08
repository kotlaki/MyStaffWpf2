using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStaffWpf2.Migrations
{
    public partial class Initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_positions_DepartmentId",
                table: "positions");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "positions");

            migrationBuilder.CreateIndex(
                name: "IX_positions_DepartmentId",
                table: "positions",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_positions_DepartmentId",
                table: "positions");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "positions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_positions_DepartmentId",
                table: "positions",
                column: "DepartmentId",
                unique: true);
        }
    }
}
