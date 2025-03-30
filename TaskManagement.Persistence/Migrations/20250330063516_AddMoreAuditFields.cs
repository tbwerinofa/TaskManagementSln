using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManagement.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreAuditFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaskStatusEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TaskStatusEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TaskEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TaskEntities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "TaskStatusEntities",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TaskStatusEntities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "TaskStatusEntities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "ModifiedBy" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskStatusEntities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TaskStatusEntities");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TaskEntities");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TaskEntities");
        }
    }
}
