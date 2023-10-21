using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_app_backend.Migrations
{
    /// <inheritdoc />
    public partial class addedAssignmentTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Assignments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TypeId",
                table: "Assignments",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_TaskTypes_TypeId",
                table: "Assignments",
                column: "TypeId",
                principalTable: "TaskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_TaskTypes_TypeId",
                table: "Assignments");

            migrationBuilder.DropTable(
                name: "TaskTypes");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_TypeId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Assignments");
        }
    }
}
