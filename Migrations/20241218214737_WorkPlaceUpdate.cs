using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    /// <inheritdoc />
    public partial class WorkPlaceUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "work_place_has_department");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "work_place",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "salary",
                type: "decimal(4)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,30)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_of_work",
                table: "employment",
                type: "decimal(4)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4,30)",
                oldPrecision: 4);

            migrationBuilder.CreateIndex(
                name: "IX_work_place_DepartmentId",
                table: "work_place",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "fk_WORK_PLACE_DEPARTMENT",
                table: "work_place",
                column: "DepartmentId",
                principalTable: "department",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_WORK_PLACE_DEPARTMENT",
                table: "work_place");

            migrationBuilder.DropIndex(
                name: "IX_work_place_DepartmentId",
                table: "work_place");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "work_place");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "salary",
                type: "decimal(4,30)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4)",
                oldPrecision: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "Price_of_work",
                table: "employment",
                type: "decimal(4,30)",
                precision: 4,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(4)",
                oldPrecision: 4);

            migrationBuilder.CreateTable(
                name: "work_place_has_department",
                columns: table => new
                {
                    WORK_PLACE_ID = table.Column<int>(type: "int", nullable: false),
                    DEPARTMENT_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.WORK_PLACE_ID, x.DEPARTMENT_ID })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "fk_WORK_PLACE_has_DEPARTMENT_DEPARTMENT1",
                        column: x => x.DEPARTMENT_ID,
                        principalTable: "department",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "fk_WORK_PLACE_has_DEPARTMENT_WORK_PLACE1",
                        column: x => x.WORK_PLACE_ID,
                        principalTable: "work_place",
                        principalColumn: "ID");
                })
                .Annotation("MySql:CharSet", "utf8mb3")
                .Annotation("Relational:Collation", "utf8mb3_general_ci");

            migrationBuilder.CreateIndex(
                name: "fk_WORK_PLACE_has_DEPARTMENT_DEPARTMENT1_idx",
                table: "work_place_has_department",
                column: "DEPARTMENT_ID");

            migrationBuilder.CreateIndex(
                name: "fk_WORK_PLACE_has_DEPARTMENT_WORK_PLACE1_idx",
                table: "work_place_has_department",
                column: "WORK_PLACE_ID");
        }
    }
}
