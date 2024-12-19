using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_And_Company_Management.Migrations
{
    /// <inheritdoc />
    public partial class WorkPlaseUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "work_place",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
        }
    }
}
