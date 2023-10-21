using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_manager_app_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssigments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpectedTimeToFinish = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParentAssignmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_Assignments_ParentAssignmentId",
                        column: x => x.ParentAssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ParentAssignmentId",
                table: "Assignments",
                column: "ParentAssignmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");
        }
    }
}
